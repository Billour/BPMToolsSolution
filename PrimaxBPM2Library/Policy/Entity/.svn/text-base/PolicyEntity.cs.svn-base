using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimaxBPM2Library.Policy.Entity
{
    /// <summary>
    ///<PRIMAX>
    ///<RULE_ENGINE>
    ///<RULES>
    ///<RULE>
    ///<CONDITION><![CDATA[#BU#=="SPD"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<RULESET ID="4" />
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#.indexOf("P")==0]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[0]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#.indexOf("L")==0 && #RANK#.substr(1)<=7]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[0]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#=="L8"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[10000]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#=="L9"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[20000]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#=="L10"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[50000]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#=="L11"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[70000]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#=="L12"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[100000]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#=="L13"]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[150000]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///<RULE>
    ///<CONDITION><![CDATA[#RANK#.indexOf("L")==0 && #RANK#.substr(1)>=14]]></CONDITION>
    ///<ACTIONS>
    ///<ACTION RESULT="true">
    ///<EXPRESSION PARAMETER="AMOUNT"><![CDATA[]]></EXPRESSION>
    ///</ACTION>
    ///</ACTIONS>
    ///</RULE>
    ///</RULES>
    ///<PARAMETERS>
    ///<PARAMETER ID="BU" DISPLAY="事業處" TYPE="string" BINDING="" VALUE="" />
    ///<PARAMETER ID="RANK" DISPLAY="職級" TYPE="string" BINDING="USER.RANK" VALUE="" />
    ///<PARAMETER ID="AMOUNT" DISPLAY="金額上限" TYPE="decimal" BINDING="" VALUE="0" />
    ///</PARAMETERS>
    ///</RULE_ENGINE>
    ///</PRIMAX>
    /// </summary>
    [XmlRoot("PRIMAX")]
    public class PolicyEntity
    {
        [XmlElement("RULE_ENGINE")]
        public RuleEngineEntity RuleEngine { get; set; }
    }
}
