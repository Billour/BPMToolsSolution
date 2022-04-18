using System;
using System.Collections.Generic;
using System.Text;

namespace Primax.Core.DB
{
    public class DBInfo
    {
        #region Field
        private String m_KeyIndex = "";
        private String m_KeyPK = "";
        private String m_KeyF = "";
        private String m_Type = "";
        private String m_Long = "";
        private String m_NotNull = "";
        private String m_FieldName = "";
        private String m_Discription = "";
        private String m_Remark = "";
        #endregion

        #region Property
        public String KeyIndex
        {
            get { return m_KeyIndex; }
            set { m_KeyIndex = value; }
        }
        public String KeyPK
        {
            get { return m_KeyPK; }
            set { m_KeyPK = value; }
        }
        public String KeyF
        {
            get { return m_KeyF; }
            set { m_KeyF = value; }
        }
        public String Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
        public String Long
        {
            get { return m_Long; }
            set { m_Long = value; }
        }
        public String NotNull
        {
            get { return m_NotNull; }
            set { m_NotNull = value; }
        }
        public String FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value; }
        }
        public String Description
        {
            get { return m_Discription; }
            set { m_Discription = value; }
        }
        public String Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }
        #endregion


    }
}
