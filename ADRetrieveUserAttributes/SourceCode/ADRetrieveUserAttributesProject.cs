using System;
using HP.ST.Fwk.RunTimeFWK;
using HP.ST.Fwk.RunTimeFWK.Utilities;
using log4net;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Text;

namespace ADRetrieveUserAttributesProject
{
    [Serializable]
     public partial class ADRetrieveUserAttributes : STActivityBase
    {
        /// <summary>
        /// The log4net Log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(ADRetrieveUserAttributes));


        ///
        /// 
        /// <summary>
        /// Initializes a new instance of the Activity class.
        /// </summary>
        /// <param name="ctx"> activitie's Context </param>
        /// <param name="name"> The activity name. </param>
        public ADRetrieveUserAttributes(ISTRunTimeContext ctx, string name)
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

                //|**************************
                //| MCAP: Set Variables 
                //|**************************

                FirstName = null;
                LastName = null;
                DisplayName = null;
                CommonName = null;
                Description = null;
                Initial = null;
                EmployeeID = null;
                EmployeeType = null;
                EmployeeNumber = null;
                Gender = null;
                Location = null;
                Address = null;
                City = null;
                ZIP_PostalCode = null;
                State = null;
                Country = null;
                CountryISOcode = null;
                UserLogonName = null;
                JobTitle = null;
                DepartmentNumber = null;
                Department = null;
                Division = null;
                Company = null;
                Manager = null;
                Email = null;
                Groups = null;

                //|**************************
                //| MCAP: LDAP Connection
                //|**************************

                DirectoryEntry dc = new DirectoryEntry(LDAP, ADCredentialUserName, ADCredentialPassword);
                
                dc.AuthenticationType = AuthenticationTypes.Secure;
                DirectorySearcher search = new DirectorySearcher(dc)
                {
                    PageSize = int.MaxValue,
                    Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName="+sAMAaccountName+"))"
                };

                string GroupMembership;
                StringBuilder groupNames = new StringBuilder();

                //|**************************
                //| MCAP: SEARCH ATTRIBUTES
                //|**************************

                search.PropertiesToLoad.Add("givenName");
                search.PropertiesToLoad.Add("sn");
                search.PropertiesToLoad.Add("displayName");
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("description");
                search.PropertiesToLoad.Add("initials");
                search.PropertiesToLoad.Add("EmployeeID");
                search.PropertiesToLoad.Add("employeeType"); //EmployeeType
                search.PropertiesToLoad.Add("EmployeeNumber");
                search.PropertiesToLoad.Add("extensionAttribute4");
                search.PropertiesToLoad.Add("physicalDeliveryOfficeName");
                search.PropertiesToLoad.Add("streetAddress");
                search.PropertiesToLoad.Add("l");
                search.PropertiesToLoad.Add("postalCode");
                search.PropertiesToLoad.Add("st");
                search.PropertiesToLoad.Add("co");
                search.PropertiesToLoad.Add("c");
                search.PropertiesToLoad.Add("userPrincipalName");
                search.PropertiesToLoad.Add("title");
                search.PropertiesToLoad.Add("departmentNumber");
                search.PropertiesToLoad.Add("department");
                search.PropertiesToLoad.Add("division");
                search.PropertiesToLoad.Add("company");
                search.PropertiesToLoad.Add("Manager");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("memberOf");
                                       
                SearchResult result = search.FindOne();

                int GroupNumber = result.Properties["memberOf"].Count;

                if (result == null)
                {
                    //return; // Or whatever you need to do in this case
                }

                //|**************************
                //| MCAP: SET ATTRIBUTES
                //|**************************

                if (result.Properties.Contains("GivenName"))
                {
                    FirstName = result.Properties["GivenName"][0].ToString();

                }

                if (result.Properties.Contains("sn"))
                {
                    LastName = result.Properties["sn"][0].ToString();

                }

                if (result.Properties.Contains("displayName"))
                {
                    DisplayName = result.Properties["displayName"][0].ToString();

                }

                if (result.Properties.Contains("cn"))
                {
                    CommonName = result.Properties["cn"][0].ToString();

                }

                if (result.Properties.Contains("description"))
                {
                    Description = result.Properties["description"][0].ToString();

                }

                if (result.Properties.Contains("initials"))
                {
                    Initial = result.Properties["initials"][0].ToString();

                }

                if (result.Properties.Contains("employeeId"))
                {
                    EmployeeID = result.Properties["employeeId"][0].ToString();

                }

                if (result.Properties.Contains("employeeType"))
                {
                    EmployeeType = result.Properties["employeeType"][0].ToString();

                }

                if (result.Properties.Contains("EmployeeNumber"))
                {
                    EmployeeNumber = result.Properties["EmployeeNumber"][0].ToString();

                }

                if (result.Properties.Contains("extensionAttribute4"))
                {
                    Gender = result.Properties["extensionAttribute4"][0].ToString();

                }

                if (result.Properties.Contains("physicalDeliveryOfficeName"))
                {
                    Location = result.Properties["physicalDeliveryOfficeName"][0].ToString();

                }

                if (result.Properties.Contains("streetAddress"))
                {
                    Address = result.Properties["streetAddress"][0].ToString();

                }

                if (result.Properties.Contains("l"))
                {
                    City = result.Properties["l"][0].ToString();

                }

                if (result.Properties.Contains("postalCode"))
                {
                    ZIP_PostalCode = result.Properties["postalCode"][0].ToString();

                }

                if (result.Properties.Contains("st"))
                {
                    State = result.Properties["st"][0].ToString();

                }

                if (result.Properties.Contains("co"))
                {
                    Country = result.Properties["co"][0].ToString();

                }

                if (result.Properties.Contains("c"))
                {
                    CountryISOcode = result.Properties["c"][0].ToString();

                }

                if (result.Properties.Contains("userPrincipalName"))
                {
                    UserLogonName = result.Properties["userPrincipalName"][0].ToString();

                }

                if (result.Properties.Contains("title"))
                {
                    JobTitle = result.Properties["title"][0].ToString();

                }

                if (result.Properties.Contains("departmentNumber"))
                {
                    DepartmentNumber = result.Properties["departmentNumber"][0].ToString();

                }

                if (result.Properties.Contains("department"))
                {
                    Department = result.Properties["department"][0].ToString();

                }

                if (result.Properties.Contains("division"))
                {
                    Division = result.Properties["division"][0].ToString();

                }

                if (result.Properties.Contains("company"))
                {
                    Company = result.Properties["company"][0].ToString();

                }

                if (result.Properties.Contains("Manager"))
                {
                    Manager = result.Properties["Manager"][0].ToString();

                }

                if (result.Properties.Contains("mail"))
                {
                    Email = result.Properties["mail"][0].ToString();

                }


                for (int counter = 0; counter < GroupNumber; counter++)
                {
                    GroupMembership = (string)result.Properties["memberOf"][counter];

                    int equalsIndex = GroupMembership.IndexOf("=", 1);
                    int commaIndex = GroupMembership.IndexOf(",", 1);

                    groupNames.Append(GroupMembership.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));

                    groupNames.Append("|");

                    Groups = groupNames.ToString();
                                      
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
