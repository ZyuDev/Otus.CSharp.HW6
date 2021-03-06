//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleBank {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class QuerySource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuerySource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SimpleBank.QuerySource", typeof(QuerySource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create Table Accounts(
        ///	Id SERIAL PRIMARY KEY,
        ///	AccountNumber VARCHAR(100) NOT NULL,
        ///	CurrencyId INTEGER NOT NULL references currencies(id),
        ///	OwnerId INTEGER NOT NULL references persons(id)
        ///).
        /// </summary>
        internal static string CreateTableAccounts {
            get {
                return ResourceManager.GetString("CreateTableAccounts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create Table Currencies(
        ///	Id SERIAL PRIMARY KEY,
        ///	Code NCHAR(3) NOT NULL,
        ///	CodeNumeric NCHAR(3) NOT NULL,
        ///	Title NCHAR(100) NOT NULL
        ///).
        /// </summary>
        internal static string CreateTableCurrencies {
            get {
                return ResourceManager.GetString("CreateTableCurrencies", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create Table Persons(
        ///	Id SERIAL PRIMARY KEY,
        ///	FirstName VARCHAR(100) NOT NULL,
        ///	LastName VARCHAR(100) NOT NULL,
        ///	MiddleName VARCHAR(100) NOT NULL,
        ///	DateOfBirth TIMESTAMP NOT NULL
        ///).
        /// </summary>
        internal static string CreateTablePersons {
            get {
                return ResourceManager.GetString("CreateTablePersons", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create Table Transactions(
        ///	Id SERIAL PRIMARY KEY,
        ///	Period TIMESTAMP NOT NULL,
        ///	Direction INTEGER NOT NULL,
        ///	AccountId INTEGER NOT NULL references accounts(id),
        ///	Amount DECIMAL NOT NULL,
        ///	info VARCHAR(200) ).
        /// </summary>
        internal static string CreateTableTransactions {
            get {
                return ResourceManager.GetString("CreateTableTransactions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO public.accounts(accountnumber, currencyid, ownerid)
        ///VALUES (@accountnumber, @currencyid, @ownerid).
        /// </summary>
        internal static string InsertAccount {
            get {
                return ResourceManager.GetString("InsertAccount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO public.persons(firstname, lastname, middlename, dateofbirth) 
        ///VALUES (@firstname, @lastname, @middlename, @dateofbirth).
        /// </summary>
        internal static string InsertPerson {
            get {
                return ResourceManager.GetString("InsertPerson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO public.transactions(period, direction, accountid, amount, info)
        ///	VALUES (@period, @direction, @accountid, @amount, @info).
        /// </summary>
        internal static string InsertTransaction {
            get {
                return ResourceManager.GetString("InsertTransaction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT EXISTS (
        ///   SELECT 1
        ///   FROM   information_schema.tables 
        ///   WHERE  table_schema = @schemaName AND 
        ///      table_name = @tableName
        ///   );.
        /// </summary>
        internal static string TableExists {
            get {
                return ResourceManager.GetString("TableExists", resourceCulture);
            }
        }
    }
}
