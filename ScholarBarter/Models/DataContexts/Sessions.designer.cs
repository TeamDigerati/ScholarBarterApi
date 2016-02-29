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

namespace ScholarBarter.Models.DataContexts
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
	public partial class SessionsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSession(Session instance);
    partial void UpdateSession(Session instance);
    partial void DeleteSession(Session instance);
    #endregion
		
		public SessionsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ApiConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SessionsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SessionsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SessionsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SessionsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Session> Sessions
		{
			get
			{
				return this.GetTable<Session>();
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
}
#pragma warning restore 1591
