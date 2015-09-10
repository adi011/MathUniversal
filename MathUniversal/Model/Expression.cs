using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using YAMP;

namespace MathUniversal
{
    public class Expression : ObservableObject
    {
        public Expression()
        {
            RemoveCommand = new RelayCommand(() => Remove());
        }
        private List<Expression> dependentExpressions = new List<Expression>();
        private List<Expression> dependsOnExpressions = new List<Expression>();
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                    return;
                ParserNameChange(value);
                RaisePropertyChanged(nameof(Name));
                searchDependencies();
            }
        }
        public RelayCommand RemoveCommand { get; }

        private void ParserNameChange(string newName)
        {
            NameErrorMessage = null;
            if (Parser.PrimaryContext.AllVariables.ContainsKey(newName) && newName != _name)    // Variable name is already used by other expression
            {
                NameErrorMessage = "Error: Name already exixts";
                _name = null;
                return;
            }
            if (!IsValidName(newName))
            {
                NameErrorMessage = "Error: Invalid name.";
                _name = null;
                return;
            }
            try
            {
                if (_name != null && Parser.PrimaryContext.AllVariables.ContainsKey(_name))
                {
                    Parser.RemoveVariable(_name);
                }
                _name = newName;
                if (!String.IsNullOrEmpty(newName))
                    Parser.AddVariable(newName, Result);
            }
            catch
            {
                NameErrorMessage = "Error: Can't change name";
            }
            finally
            {
                dependentExpressions.ForEach((e) => e.ParseExpression());
                dependentExpressions.Clear();   // After changing name dependencies change too.
            }
        }

        private bool IsValidName(string newName)
        {
            if (String.IsNullOrEmpty(newName))  // Can be not named
                return true;
            if (!char.IsLetter(newName.FirstOrDefault()))   // First char must be a letter
                return false;
            if (newName.All(c => Char.IsLetterOrDigit(c)))  // All chars must be letter or digit
                return true;
            else
                return false;
        }

        private void searchDependencies()
        {
            foreach (var e in MathExpressions.Instance.Expressions)
            {
                var parse = Parser.Parse(e.ExpressionString);
                if (parse.Context.Parser.CollectedSymbols.Contains(this.Name))
                {
                    dependentExpressions.Add(e);
                }
            }
            NotifyDependentExpressions(this);
        }

        private string _expressionString;

        public string ExpressionString
        {
            get
            {
                return _expressionString;
            }

            set
            {
                if (_expressionString == value)
                {
                    return;
                }

                _expressionString = value;
                RaisePropertyChanged(nameof(ExpressionString));
                ParseExpression();
            }
        }
        private Value _result;
        public Value Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (_result == value)
                {
                    return;
                }
                _result = value;
                RaisePropertyChanged(nameof(Result));
                RaisePropertyChanged(nameof(ResultString));
            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (_errorMessage == value)
                {
                    return;
                }

                _errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
                RaisePropertyChanged(nameof(ResultString));
                var sources = new List<Expression>();
                sources.Add(this);
            }
        }

        private string _nameErrorMessage;

        public string NameErrorMessage
        {
            get
            {
                return _nameErrorMessage;
            }
            set
            {
                _nameErrorMessage = value;
                RaisePropertyChanged(nameof(NameErrorMessage));
            }
        }
        public string ResultString => Result!=null  ?   Result.ToString()   :   ErrorMessage;

        public void ParseExpression(Expression source = null)
        {
            try
            {
                if (!String.IsNullOrEmpty(Name) && Parser.PrimaryContext.AllVariables.ContainsKey(Name))    // Remove old value from parser
                {
                    Parser.RemoveVariable(Name);
                }
                var parser = Parser.Parse(ExpressionString);
                var usedSymbols = parser.Context.Parser.CollectedSymbols;
                var dependsOn = MathExpressions.Instance.Expressions.Where(s => usedSymbols.Contains(s.Name)).ToList(); // Get expressions that are used by this expression.
                UpdateDependentOn(dependsOn);
                if (source == this)     // Detecs infinite dependency loop.
                {
                    Result = null;
                    ErrorMessage = "Error. Infinite dependecy loop.";
                    NotifyDependencyLoop();
                    return;
                }
                if (source == null)
                    source = this;
                var result = parser.Execute();
                if (!String.IsNullOrEmpty(Name))    // Variable must be named to be aded to parser
                {
                    Parser.AddVariable(Name, result);
                }
                Result = result;
                ErrorMessage = null;
                NotifyDependentExpressions(source);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Result = null;
                NotifyDependentExpressions(source);
            }
        }

        private void UpdateDependentOn(List<Expression> dependsOn)
        {
            foreach (var e in dependsOnExpressions.Except(dependsOn).ToArray())
            {
                e.RemoveDependentExpression(this);
                dependsOnExpressions.Remove(e);
            }
            foreach (var e in dependsOn.Except(dependsOnExpressions).ToArray())
            {
                e.AddDependentExpression(this);
                dependsOnExpressions.Add(e);
            }
        }

        public void AddDependentExpression(Expression e)
        {
            if (e != this && !dependentExpressions.Contains(e))
                dependentExpressions.Add(e);
        }
        public void RemoveDependentExpression(Expression e)
        {
            dependentExpressions.Remove(e);
        }

        private void NotifyDependentExpressions(Expression source)
        {
            foreach (Expression e in dependentExpressions.ToList())
            {
                e.ParseExpression(source);
            }
        }
        public void NotifyDependencyLoop(Expression source = null)
        {
            if (source == null || source != this)
            {
                if (source == null)
                    source = this;
                Result = null;
                ErrorMessage = "Error. Infinite dependecy loop.";
                foreach (Expression e in dependentExpressions.ToList())
                {
                    e.NotifyDependencyLoop(source);
                }
            }
        }
        public void PrepareToRemove()
        {
            if (!String.IsNullOrEmpty(Name) && Parser.PrimaryContext.AllVariables.ContainsKey(Name))    // Remove variable from parser
            {
                Parser.RemoveVariable(Name);
            }
            NotifyDependentExpressions(this);
            foreach (Expression e in dependsOnExpressions)
            {
                e.RemoveDependentExpression(this);
            }
            dependentExpressions = null;
            dependsOnExpressions = null;
            Result = null;
        }


        private void Remove()
        {
            PrepareToRemove();
            MathExpressions.Instance.Expressions.Remove(this);
        }
    }
}