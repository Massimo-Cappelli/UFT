//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFTPDownLoadProject
{
    using System;
    using HP.ST.Fwk.RunTimeFWK;
    
    
    public partial class SFTPDownLoad
    {
        
        private string _sftpserver;
        
        private string _sftppath;
        
        private string _filemask;
        
        private string _sftpuser;
        
        private string _sftppassword;
        
        private string _localpath;
        
        private int _fileprocessed;
        
        private string _name;
        
        //  InputProperties Section
        [Report()]
        public virtual string SFTPServer
        {
            get
            {
                return this._sftpserver;
            }
            set
            {
                this._sftpserver = value;
            }
        }
        
        [Report()]
        public virtual string SFTPPath
        {
            get
            {
                return this._sftppath;
            }
            set
            {
                this._sftppath = value;
            }
        }
        
        [Report()]
        public virtual string FileMask
        {
            get
            {
                return this._filemask;
            }
            set
            {
                this._filemask = value;
            }
        }
        
        [Report()]
        public virtual string SFTPUser
        {
            get
            {
                return this._sftpuser;
            }
            set
            {
                this._sftpuser = value;
            }
        }
        
        [Report()]
        public virtual string SFTPPassword
        {
            get
            {
                return this._sftppassword;
            }
            set
            {
                this._sftppassword = value;
            }
        }
        
        [Report()]
        public virtual string LocalPath
        {
            get
            {
                return this._localpath;
            }
            set
            {
                this._localpath = value;
            }
        }
        
        //  OutputProperties Section
        [Report()]
        public virtual int FileProcessed
        {
            get
            {
                return this._fileprocessed;
            }
            set
            {
                this._fileprocessed = value;
            }
        }
        
        //  GeneralProperties Section
        [Report()]
        public virtual string Name
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
    }
}
