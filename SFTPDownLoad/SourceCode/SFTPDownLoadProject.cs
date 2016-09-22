using System;
using HP.ST.Fwk.RunTimeFWK;
using HP.ST.Fwk.RunTimeFWK.Utilities;
using log4net;
using WinSCP;

namespace SFTPDownLoadProject
{
    [Serializable]
     public partial class SFTPDownLoad : STActivityBase
    {
        /// <summary>
        /// The log4net Log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SFTPDownLoad));

        /// <summary>
        /// Initializes a new instance of the Activity class.
        /// </summary>
        /// <param name="ctx"> activitie's Context </param>
        /// <param name="name"> The activity name. </param>
        public SFTPDownLoad(ISTRunTimeContext ctx, string name)
            : base(ctx, name)
        {
            
        }

        /// <summary>
        /// Execue and set results
        /// </summary>
        /// <returns></returns>
       protected override STExecutionResult ExecuteStep()
       {
            try
            {
                //|********************************
                //| MCAP: SET SESSION PARAMETERS 
                //|********************************
                SessionOptions sessionOptions = new SessionOptions
                {

                    Protocol = Protocol.Sftp,
                    HostName = SFTPServer,
                    UserName = SFTPUser,
                    Password = SFTPPassword,
                   
                };

                FileProcessed = 0;

                using (Session session = new Session())

                {
                    //|********************************
                    //| MCAP: GENERATE FINGERPRINTS
                    //|********************************

                    string fingerprint = session.ScanFingerprint(sessionOptions);
                    sessionOptions.SshHostKeyFingerprint = fingerprint;

                    session.Open(sessionOptions);

                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;

                    transferResult = session.GetFiles(SFTPPath + FileMask, LocalPath, false, transferOptions);

                    transferResult.Check();

                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        FileProcessed++;
                    }

                 }
                    return new STExecutionResult(STExecutionStatus.Success);
            }
            catch (Exception e)
            {
                return new STExecutionResult(STExecutionStatus.ActivityFailure);
            }
        }
    }
}
