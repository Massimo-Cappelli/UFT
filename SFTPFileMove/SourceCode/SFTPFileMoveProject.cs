using System;
using HP.ST.Fwk.RunTimeFWK;
using HP.ST.Fwk.RunTimeFWK.Utilities;
using log4net;
using WinSCP;

namespace SFTPFileMoveProject
{
    [Serializable]
     public partial class SFTPFileMove : STActivityBase
    {
        /// <summary>
        /// The log4net Log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SFTPFileMove));

        /// <summary>
        /// Initializes a new instance of the Activity class.
        /// </summary>
        /// <param name="ctx"> activitie's Context </param>
        /// <param name="name"> The activity name. </param>
        public SFTPFileMove(ISTRunTimeContext ctx, string name)
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
                //**************************
                // Execution code goes here 
                //**************************

                SessionOptions sessionOptions = new SessionOptions
                {

                    Protocol = Protocol.Sftp,
                    HostName = SFTPServer,
                    UserName = SFTPUser,
                    Password = SFTPPassword,
                    

                };


                using (Session session = new Session())

                {
                    string fingerprint = session.ScanFingerprint(sessionOptions);
                    sessionOptions.SshHostKeyFingerprint = fingerprint;

                    session.Open(sessionOptions);

                    
                    session.MoveFile(SFTPFromPath+FileMask, SFTPToPath);

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
