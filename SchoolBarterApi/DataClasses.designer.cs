﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScholarBarterApi
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Api")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBook(Book instance);
    partial void UpdateBook(Book instance);
    partial void DeleteBook(Book instance);
    partial void InsertConditionType(ConditionType instance);
    partial void UpdateConditionType(ConditionType instance);
    partial void DeleteConditionType(ConditionType instance);
    partial void InsertListing(Listing instance);
    partial void UpdateListing(Listing instance);
    partial void DeleteListing(Listing instance);
    partial void InsertListingType(ListingType instance);
    partial void UpdateListingType(ListingType instance);
    partial void DeleteListingType(ListingType instance);
    partial void InsertSession(Session instance);
    partial void UpdateSession(Session instance);
    partial void DeleteSession(Session instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertAccountValidation(AccountValidation instance);
    partial void UpdateAccountValidation(AccountValidation instance);
    partial void DeleteAccountValidation(AccountValidation instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ApiConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Book> Books
		{
			get
			{
				return this.GetTable<Book>();
			}
		}
		
		public System.Data.Linq.Table<ConditionType> ConditionTypes
		{
			get
			{
				return this.GetTable<ConditionType>();
			}
		}
		
		public System.Data.Linq.Table<Listing> Listings
		{
			get
			{
				return this.GetTable<Listing>();
			}
		}
		
		public System.Data.Linq.Table<ListingType> ListingTypes
		{
			get
			{
				return this.GetTable<ListingType>();
			}
		}
		
		public System.Data.Linq.Table<Session> Sessions
		{
			get
			{
				return this.GetTable<Session>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<UserListing> UserListings
		{
			get
			{
				return this.GetTable<UserListing>();
			}
		}
		
		public System.Data.Linq.Table<AccountValidation> AccountValidations
		{
			get
			{
				return this.GetTable<AccountValidation>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Books")]
	public partial class Book : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BookId;
		
		private int _ListingId;
		
		private string _Isbn10;
		
		private string _Condition;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBookIdChanging(int value);
    partial void OnBookIdChanged();
    partial void OnListingIdChanging(int value);
    partial void OnListingIdChanged();
    partial void OnIsbn10Changing(string value);
    partial void OnIsbn10Changed();
    partial void OnConditionChanging(string value);
    partial void OnConditionChanged();
    #endregion
		
		public Book()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BookId
		{
			get
			{
				return this._BookId;
			}
			set
			{
				if ((this._BookId != value))
				{
					this.OnBookIdChanging(value);
					this.SendPropertyChanging();
					this._BookId = value;
					this.SendPropertyChanged("BookId");
					this.OnBookIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListingId", DbType="Int NOT NULL")]
		public int ListingId
		{
			get
			{
				return this._ListingId;
			}
			set
			{
				if ((this._ListingId != value))
				{
					this.OnListingIdChanging(value);
					this.SendPropertyChanging();
					this._ListingId = value;
					this.SendPropertyChanged("ListingId");
					this.OnListingIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Isbn10", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string Isbn10
		{
			get
			{
				return this._Isbn10;
			}
			set
			{
				if ((this._Isbn10 != value))
				{
					this.OnIsbn10Changing(value);
					this.SendPropertyChanging();
					this._Isbn10 = value;
					this.SendPropertyChanged("Isbn10");
					this.OnIsbn10Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Condition", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string Condition
		{
			get
			{
				return this._Condition;
			}
			set
			{
				if ((this._Condition != value))
				{
					this.OnConditionChanging(value);
					this.SendPropertyChanging();
					this._Condition = value;
					this.SendPropertyChanged("Condition");
					this.OnConditionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ConditionTypes")]
	public partial class ConditionType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Condition;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConditionChanging(string value);
    partial void OnConditionChanged();
    #endregion
		
		public ConditionType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Condition", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Condition
		{
			get
			{
				return this._Condition;
			}
			set
			{
				if ((this._Condition != value))
				{
					this.OnConditionChanging(value);
					this.SendPropertyChanging();
					this._Condition = value;
					this.SendPropertyChanged("Condition");
					this.OnConditionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Listings")]
	public partial class Listing : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ListingId;
		
		private int _UserId;
		
		private bool _Active;
		
		private string _ListingType;
		
		private string _Title;
		
		private string _Description;
		
		private System.DateTime _CreationTime;
		
		private System.Nullable<decimal> _Price;
		
		private System.Nullable<int> _Quantity;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnListingIdChanging(int value);
    partial void OnListingIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    partial void OnListingTypeChanging(string value);
    partial void OnListingTypeChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnCreationTimeChanging(System.DateTime value);
    partial void OnCreationTimeChanged();
    partial void OnPriceChanging(System.Nullable<decimal> value);
    partial void OnPriceChanged();
    partial void OnQuantityChanging(System.Nullable<int> value);
    partial void OnQuantityChanged();
    #endregion
		
		public Listing()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListingId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ListingId
		{
			get
			{
				return this._ListingId;
			}
			set
			{
				if ((this._ListingId != value))
				{
					this.OnListingIdChanging(value);
					this.SendPropertyChanging();
					this._ListingId = value;
					this.SendPropertyChanged("ListingId");
					this.OnListingIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListingType", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string ListingType
		{
			get
			{
				return this._ListingType;
			}
			set
			{
				if ((this._ListingType != value))
				{
					this.OnListingTypeChanging(value);
					this.SendPropertyChanging();
					this._ListingType = value;
					this.SendPropertyChanged("ListingType");
					this.OnListingTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationTime", DbType="DateTime NOT NULL")]
		public System.DateTime CreationTime
		{
			get
			{
				return this._CreationTime;
			}
			set
			{
				if ((this._CreationTime != value))
				{
					this.OnCreationTimeChanging(value);
					this.SendPropertyChanging();
					this._CreationTime = value;
					this.SendPropertyChanged("CreationTime");
					this.OnCreationTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(5,2)")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ListingTypes")]
	public partial class ListingType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Type;
		
		private string _Description;
		
		private bool _Active;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnActiveChanging(bool value);
    partial void OnActiveChanged();
    #endregion
		
		public ListingType()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="VarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sessions")]
	public partial class Session : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _SessionId;
		
		private int _UserId;
		
		private string _SessionKey;
		
		private System.DateTime _ValidationTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSessionIdChanging(int value);
    partial void OnSessionIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnSessionKeyChanging(string value);
    partial void OnSessionKeyChanged();
    partial void OnValidationTimeChanging(System.DateTime value);
    partial void OnValidationTimeChanged();
    #endregion
		
		public Session()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SessionId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int SessionId
		{
			get
			{
				return this._SessionId;
			}
			set
			{
				if ((this._SessionId != value))
				{
					this.OnSessionIdChanging(value);
					this.SendPropertyChanging();
					this._SessionId = value;
					this.SendPropertyChanged("SessionId");
					this.OnSessionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SessionKey", DbType="Char(32) NOT NULL", CanBeNull=false)]
		public string SessionKey
		{
			get
			{
				return this._SessionKey;
			}
			set
			{
				if ((this._SessionKey != value))
				{
					this.OnSessionKeyChanging(value);
					this.SendPropertyChanging();
					this._SessionKey = value;
					this.SendPropertyChanged("SessionKey");
					this.OnSessionKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValidationTime", DbType="DateTime NOT NULL")]
		public System.DateTime ValidationTime
		{
			get
			{
				return this._ValidationTime;
			}
			set
			{
				if ((this._ValidationTime != value))
				{
					this.OnValidationTimeChanging(value);
					this.SendPropertyChanging();
					this._ValidationTime = value;
					this.SendPropertyChanged("ValidationTime");
					this.OnValidationTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Username;
		
		private string _EduEmail;
		
		private string _Email;
		
		private string _PasswordHash;
		
		private bool _Enabled;
		
		private System.DateTime _CreationTime;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Gender;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnEduEmailChanging(string value);
    partial void OnEduEmailChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordHashChanging(string value);
    partial void OnPasswordHashChanged();
    partial void OnEnabledChanging(bool value);
    partial void OnEnabledChanged();
    partial void OnCreationTimeChanging(System.DateTime value);
    partial void OnCreationTimeChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnGenderChanging(string value);
    partial void OnGenderChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EduEmail", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
		public string EduEmail
		{
			get
			{
				return this._EduEmail;
			}
			set
			{
				if ((this._EduEmail != value))
				{
					this.OnEduEmailChanging(value);
					this.SendPropertyChanging();
					this._EduEmail = value;
					this.SendPropertyChanged("EduEmail");
					this.OnEduEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordHash", DbType="VarChar(32) NOT NULL", CanBeNull=false)]
		public string PasswordHash
		{
			get
			{
				return this._PasswordHash;
			}
			set
			{
				if ((this._PasswordHash != value))
				{
					this.OnPasswordHashChanging(value);
					this.SendPropertyChanging();
					this._PasswordHash = value;
					this.SendPropertyChanged("PasswordHash");
					this.OnPasswordHashChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enabled", DbType="Bit NOT NULL")]
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				if ((this._Enabled != value))
				{
					this.OnEnabledChanging(value);
					this.SendPropertyChanging();
					this._Enabled = value;
					this.SendPropertyChanged("Enabled");
					this.OnEnabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationTime", DbType="DateTime NOT NULL")]
		public System.DateTime CreationTime
		{
			get
			{
				return this._CreationTime;
			}
			set
			{
				if ((this._CreationTime != value))
				{
					this.OnCreationTimeChanging(value);
					this.SendPropertyChanging();
					this._CreationTime = value;
					this.SendPropertyChanged("CreationTime");
					this.OnCreationTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(10)")]
		public string Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserListings")]
	public partial class UserListing
	{
		
		private int _ListingId;
		
		private int _UserId;
		
		private bool _Active;
		
		private string _ListingType;
		
		private string _Title;
		
		private string _Description;
		
		private System.DateTime _CreationTime;
		
		private System.Nullable<decimal> _Price;
		
		private System.Nullable<int> _Quantity;
		
		private string _FirstName;
		
		private string _LastName;
		
		private bool _Enabled;
		
		public UserListing()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListingId", DbType="Int NOT NULL")]
		public int ListingId
		{
			get
			{
				return this._ListingId;
			}
			set
			{
				if ((this._ListingId != value))
				{
					this._ListingId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit NOT NULL")]
		public bool Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this._Active = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListingType", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string ListingType
		{
			get
			{
				return this._ListingType;
			}
			set
			{
				if ((this._ListingType != value))
				{
					this._ListingType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationTime", DbType="DateTime NOT NULL")]
		public System.DateTime CreationTime
		{
			get
			{
				return this._CreationTime;
			}
			set
			{
				if ((this._CreationTime != value))
				{
					this._CreationTime = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(5,2)")]
		public System.Nullable<decimal> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int")]
		public System.Nullable<int> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this._Quantity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50)")]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50)")]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enabled", DbType="Bit NOT NULL")]
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				if ((this._Enabled != value))
				{
					this._Enabled = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AccountValidations")]
	public partial class AccountValidation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _UserId;
		
		private string _ValidationKey;
		
		private System.DateTime _CreationTime;
		
		private System.Nullable<System.DateTime> _ValidationTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnValidationKeyChanging(string value);
    partial void OnValidationKeyChanged();
    partial void OnCreationTimeChanging(System.DateTime value);
    partial void OnCreationTimeChanged();
    partial void OnValidationTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnValidationTimeChanged();
    #endregion
		
		public AccountValidation()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValidationKey", DbType="Char(32) NOT NULL", CanBeNull=false)]
		public string ValidationKey
		{
			get
			{
				return this._ValidationKey;
			}
			set
			{
				if ((this._ValidationKey != value))
				{
					this.OnValidationKeyChanging(value);
					this.SendPropertyChanging();
					this._ValidationKey = value;
					this.SendPropertyChanged("ValidationKey");
					this.OnValidationKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreationTime", DbType="DateTime NOT NULL")]
		public System.DateTime CreationTime
		{
			get
			{
				return this._CreationTime;
			}
			set
			{
				if ((this._CreationTime != value))
				{
					this.OnCreationTimeChanging(value);
					this.SendPropertyChanging();
					this._CreationTime = value;
					this.SendPropertyChanged("CreationTime");
					this.OnCreationTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ValidationTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> ValidationTime
		{
			get
			{
				return this._ValidationTime;
			}
			set
			{
				if ((this._ValidationTime != value))
				{
					this.OnValidationTimeChanging(value);
					this.SendPropertyChanging();
					this._ValidationTime = value;
					this.SendPropertyChanged("ValidationTime");
					this.OnValidationTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
