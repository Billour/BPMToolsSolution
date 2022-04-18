using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using log4net;

namespace Primax.Core.DB
{
    /// <summary>
    /// DB���֤�
    /// </summary>
    public abstract class AbstractDbTrans
    {
        /// <summary>
        /// �Ұ�log4net
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(AbstractDbTrans));

        public AbstractDbTrans(String TemplateFilePath, String TargetFolder, String TargetFileSavePath)
        {
            if (File.Exists(TemplateFilePath))
            {
                if (!Directory.Exists(TargetFolder))
                {
                    Directory.CreateDirectory(TargetFolder);
                }

                log.Info("�s�W�ؿ�" + TemplateFilePath);

            }
            else
            {
                throw new Exception("�ɮץؿ��p�U�G" + TemplateFilePath);
            }
        }

        public abstract Boolean HeaderData(String TableNameDescription, String TableName, String Version, String ProjectName, String Today);

        public abstract Boolean InsertDBInfo(List<DBInfo> dbList);

        public abstract Boolean Save();

        public abstract void Close();

    }
}
