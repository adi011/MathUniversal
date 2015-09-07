using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using YAMP;

namespace MathUniversal
{
    public class Expression:ObservableObject
    {
        public Expression()
        {
        }
        private List<Expression> dependentExpressions=new List<Expression>();
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
                RaisePropertyChanged("Name");
                searchDependencies();
            }
        }

        private void ParserNameChange(string newName)
        {
            NameErrorMessage = null;
            if(Parser.PrimaryContext.AllVariables.ContainsKey(newName) && newName != _name)    // Variable name is already used by other expression
            {
                NameErrorMessage = "Error: Name already exixts";
                _name = null;
                return;
            }
            try
                {
                if (_name!=null && Parser.PrimaryContext.AllVariables.ContainsKey(_name))
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

        private void searchDependencies()
        {
            foreach(var e in MathExpressions.Instance.Expressions)
            {
                var parse = Parser.Parse(e.ExpressionString);
                if (parse.Context.Parser.CollectedSymbols.Contains(this.Name))
                {
                    dependentExpressions.Add(e);
                }
            }
            var sources = new List<Expression>();
            sources.Add(this);
            NotifyDependentExpressions(sources);
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
                RaisePropertyChanged("ExpressionString");
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
                RaisePropertyChanged("Result");
                RaisePropertyChanged("ResultString");
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
                RaisePropertyChanged("ErrorMessage");
                RaisePropertyChanged("ResultString");
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
                RaisePropertyChanged("NameErrorMessage");
            }
        }
        public string ResultString
        {
            get
            {
                if (Result != null)
                {
                    return Result.ToString();
                }else
                {
                    return ErrorMessage;
                }
            }
        }

        public bool ParseExpression(List<Expression> sources=null)
        {
            if (sources!=null && ErrorMessage == "Error. Infinite dependecy loop.")
                return false;
            if (String.IsNullOrEmpty(ExpressionString))
            {
                Result = null;
                ErrorMessage = null;
                return true;
            }
            if (!String.IsNullOrEmpty(Name) && Parser.PrimaryContext.AllVariables.ContainsKey(Name))
            {
                Parser.RemoveVariable(Name);
            }
            try
            {
                var parser = Parser.Parse(ExpressionString);
                var usedSymbols = parser.Context.Parser.CollectedSymbols;
                var dependsOn = MathExpressions.Instance.Expressions.Where(s => usedSymbols.Contains(s.Name)).ToList();
                UpdateDependentOn(dependsOn);
                if (sources == null)
                    sources = new List<Expression>();
                if (sources.Contains(this))
                {
                    Result = null;
                    ErrorMessage = "Error. Infinite dependecy loop.";
                    return false;
                }
                else
                {
                    sources.Add(this);
                }
                var result = parser.Execute();
                if (!String.IsNullOrEmpty(Name))
                {
                    Parser.AddVariable(Name, result);
                }
                Result = result;
                ErrorMessage = null;
                return true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Result = null;
                return true;
            }
            finally
            {
                NotifyDependentExpressions(sources);
            }
        }

        private void UpdateDependentOn(List<Expression> dependsOn)
        {
            foreach(var e in dependsOnExpressions.Except(dependsOn).ToArray())
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
            if(e!=this && !dependentExpressions.Contains(e))
            dependentExpressions.Add(e);
        }
        public void RemoveDependentExpression(Expression e)
        {
            dependentExpressions.Remove(e);
        }

        private void NotifyDependentExpressions(List<Expression> sources)
        {
            dependentExpressions.ForEach((e) => 
            {
                if(!e.ParseExpression(sources))
                {
                    Result = null;
                    ErrorMessage = "Error. Infinite dependency loop";
                }
             });
        }
    }
}