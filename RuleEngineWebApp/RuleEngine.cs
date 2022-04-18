using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.JScript;
using System.Globalization;

namespace RuleEngineWebApp
{
    public class RuleEngine
    {
        // Fields
        private RuleSet _ruleset = null;

        // Methods
        public RuleEngine(RuleSet ruleset)
        {
            this._ruleset = ruleset;
        }

        public void Execute()
        {
            try
            {
                foreach (XmlNode node in this._ruleset.Rules.SelectNodes("//RULE"))
                {
                    string innerText = node.SelectSingleNode("CONDITION").InnerText;
                    foreach (XmlNode node2 in this._ruleset.Rules.SelectNodes("//PARAMETERS/PARAMETER"))
                    {
                        if (node2.Attributes["TYPE"].Value.ToLower() == "string")
                        {
                            innerText = innerText.Replace("#" + node2.Attributes["ID"].Value + "#", "\"" + node2.Attributes["VALUE"].Value + "\"");
                        }
                        else
                        {
                            innerText = innerText.Replace("#" + node2.Attributes["ID"].Value + "#", node2.Attributes["VALUE"].Value);
                        }
                    }
                    if (ExpressionEvaluator.EvaluateToString(innerText) == "true")
                    {
                        XmlNode node3 = node.SelectSingleNode("ACTIONS/ACTION[@RESULT='true']");
                        if (node3 != null)
                        {
                            foreach (XmlNode node4 in node3.SelectNodes("EXPRESSION"))
                            {
                                string str2 = "";
                                if (!node4.InnerText.StartsWith("!POLICY."))
                                {
                                    str2 = node4.InnerText;
                                }
                                this._ruleset.Rules.SelectSingleNode("//PARAMETERS/PARAMETER[@ID='" + node4.Attributes["PARAMETER"].Value + "']").Attributes["VALUE"].Value = str2;
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Properties
        public RuleSet RuleSet
        {
            get
            {
                return this._ruleset;
            }
        }
    }

    public class ExpressionEvaluator
    {
        // Fields
        private static object _evaluator = GetEvaluator();
        private const string _evaluatorSourceCode = "package Evaluator \r\n            { \r\n               class Evaluator \r\n               { \r\n                  public function Eval(expr : String) : String  \r\n                  {  \r\n                     return eval(expr);  \r\n                  } \r\n               } \r\n            }";
        private static Type _evaluatorType;

        // Methods
        public static object EvaluateToObject(string statement)
        {
            lock (_evaluator)
            {
                return _evaluatorType.InvokeMember("Eval", BindingFlags.InvokeMethod, null, _evaluator, new object[] { statement }, CultureInfo.CurrentCulture);
            }
        }

        public static string EvaluateToString(string statement)
        {
            return EvaluateToObject(statement).ToString();
        }

        private static object GetEvaluator()
        {
            CompilerParameters options = new CompilerParameters();
            options.GenerateInMemory = true;
            JScriptCodeProvider provider = new JScriptCodeProvider();
            _evaluatorType = provider.CompileAssemblyFromSource(options, new string[] { "package Evaluator \r\n            { \r\n               class Evaluator \r\n               { \r\n                  public function Eval(expr : String) : String  \r\n                  {  \r\n                     return eval(expr);  \r\n                  } \r\n               } \r\n            }" }).CompiledAssembly.GetType("Evaluator.Evaluator");
            return Activator.CreateInstance(_evaluatorType);
        }
    }

    public class RuleSet
    {
        // Fields
        private string _name = null;
        private XmlDocument _rules = null;

        // Methods
        public RuleSet(string name, string rules)
        {
            this._name = name;
            this._rules = new XmlDocument();
            this._rules.LoadXml(rules);
        }

        // Properties
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public XmlDocument Rules
        {
            get
            {
                return this._rules;
            }
        }
    }


}
