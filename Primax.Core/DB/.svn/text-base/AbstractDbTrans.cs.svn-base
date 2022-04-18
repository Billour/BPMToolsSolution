using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using log4net;

namespace Primax.Core.DB
{
    /// <summary>
    /// DB的核心
    /// </summary>
    public abstract class AbstractDbTrans
    {
        /// <summary>
        /// 啟動log4net
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

                log.Info("新增目錄" + TemplateFilePath);

            }
            else
            {
                throw new Exception("檔案目錄如下：" + TemplateFilePath);
            }
        }

        public abstract Boolean HeaderData(String TableNameDescription, String TableName, String Version, String ProjectName, String Today);

        public abstract Boolean InsertDBInfo(List<DBInfo> dbList);

        public abstract Boolean Save();

        public abstract void Close();

    }
}
