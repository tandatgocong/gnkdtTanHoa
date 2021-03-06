﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMACData
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="tanhoa")]
	public partial class DataBaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertt_Channel_Configuration(t_Channel_Configuration instance);
    partial void Updatet_Channel_Configuration(t_Channel_Configuration instance);
    partial void Deletet_Channel_Configuration(t_Channel_Configuration instance);
    #endregion
		
		public DataBaseDataContext() : 
				base(global::PMACData.Properties.Settings.Default.tanhoaConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<t_Channel_Configuration> t_Channel_Configurations
		{
			get
			{
				return this.GetTable<t_Channel_Configuration>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_Channel_Configurations")]
	public partial class t_Channel_Configuration : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ChannelId;
		
		private string _LoggerId;
		
		private string _ChannelName;
		
		private string _Unit;
		
		private string _Description;
		
		private System.Nullable<bool> _Pressure1;
		
		private System.Nullable<bool> _Pressure2;
		
		private System.Nullable<bool> _ForwardFlow;
		
		private System.Nullable<bool> _ReverseFlow;
		
		private System.Nullable<System.DateTime> _TimeStamp;
		
		private System.Nullable<double> _LastValue;
		
		private System.Nullable<System.DateTime> _IndexTimeStamp;
		
		private System.Nullable<double> _LastIndex;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnChannelIdChanging(string value);
    partial void OnChannelIdChanged();
    partial void OnLoggerIdChanging(string value);
    partial void OnLoggerIdChanged();
    partial void OnChannelNameChanging(string value);
    partial void OnChannelNameChanged();
    partial void OnUnitChanging(string value);
    partial void OnUnitChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnPressure1Changing(System.Nullable<bool> value);
    partial void OnPressure1Changed();
    partial void OnPressure2Changing(System.Nullable<bool> value);
    partial void OnPressure2Changed();
    partial void OnForwardFlowChanging(System.Nullable<bool> value);
    partial void OnForwardFlowChanged();
    partial void OnReverseFlowChanging(System.Nullable<bool> value);
    partial void OnReverseFlowChanged();
    partial void OnTimeStampChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeStampChanged();
    partial void OnLastValueChanging(System.Nullable<double> value);
    partial void OnLastValueChanged();
    partial void OnIndexTimeStampChanging(System.Nullable<System.DateTime> value);
    partial void OnIndexTimeStampChanged();
    partial void OnLastIndexChanging(System.Nullable<double> value);
    partial void OnLastIndexChanged();
    #endregion
		
		public t_Channel_Configuration()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelId", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ChannelId
		{
			get
			{
				return this._ChannelId;
			}
			set
			{
				if ((this._ChannelId != value))
				{
					this.OnChannelIdChanging(value);
					this.SendPropertyChanging();
					this._ChannelId = value;
					this.SendPropertyChanged("ChannelId");
					this.OnChannelIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoggerId", DbType="VarChar(50)")]
		public string LoggerId
		{
			get
			{
				return this._LoggerId;
			}
			set
			{
				if ((this._LoggerId != value))
				{
					this.OnLoggerIdChanging(value);
					this.SendPropertyChanging();
					this._LoggerId = value;
					this.SendPropertyChanged("LoggerId");
					this.OnLoggerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelName", DbType="NVarChar(50)")]
		public string ChannelName
		{
			get
			{
				return this._ChannelName;
			}
			set
			{
				if ((this._ChannelName != value))
				{
					this.OnChannelNameChanging(value);
					this.SendPropertyChanging();
					this._ChannelName = value;
					this.SendPropertyChanged("ChannelName");
					this.OnChannelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unit", DbType="NVarChar(50)")]
		public string Unit
		{
			get
			{
				return this._Unit;
			}
			set
			{
				if ((this._Unit != value))
				{
					this.OnUnitChanging(value);
					this.SendPropertyChanging();
					this._Unit = value;
					this.SendPropertyChanged("Unit");
					this.OnUnitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(4000)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pressure1", DbType="Bit")]
		public System.Nullable<bool> Pressure1
		{
			get
			{
				return this._Pressure1;
			}
			set
			{
				if ((this._Pressure1 != value))
				{
					this.OnPressure1Changing(value);
					this.SendPropertyChanging();
					this._Pressure1 = value;
					this.SendPropertyChanged("Pressure1");
					this.OnPressure1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pressure2", DbType="Bit")]
		public System.Nullable<bool> Pressure2
		{
			get
			{
				return this._Pressure2;
			}
			set
			{
				if ((this._Pressure2 != value))
				{
					this.OnPressure2Changing(value);
					this.SendPropertyChanging();
					this._Pressure2 = value;
					this.SendPropertyChanged("Pressure2");
					this.OnPressure2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ForwardFlow", DbType="Bit")]
		public System.Nullable<bool> ForwardFlow
		{
			get
			{
				return this._ForwardFlow;
			}
			set
			{
				if ((this._ForwardFlow != value))
				{
					this.OnForwardFlowChanging(value);
					this.SendPropertyChanging();
					this._ForwardFlow = value;
					this.SendPropertyChanged("ForwardFlow");
					this.OnForwardFlowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReverseFlow", DbType="Bit")]
		public System.Nullable<bool> ReverseFlow
		{
			get
			{
				return this._ReverseFlow;
			}
			set
			{
				if ((this._ReverseFlow != value))
				{
					this.OnReverseFlowChanging(value);
					this.SendPropertyChanging();
					this._ReverseFlow = value;
					this.SendPropertyChanged("ReverseFlow");
					this.OnReverseFlowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeStamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> TimeStamp
		{
			get
			{
				return this._TimeStamp;
			}
			set
			{
				if ((this._TimeStamp != value))
				{
					this.OnTimeStampChanging(value);
					this.SendPropertyChanging();
					this._TimeStamp = value;
					this.SendPropertyChanged("TimeStamp");
					this.OnTimeStampChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastValue", DbType="Float")]
		public System.Nullable<double> LastValue
		{
			get
			{
				return this._LastValue;
			}
			set
			{
				if ((this._LastValue != value))
				{
					this.OnLastValueChanging(value);
					this.SendPropertyChanging();
					this._LastValue = value;
					this.SendPropertyChanged("LastValue");
					this.OnLastValueChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IndexTimeStamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> IndexTimeStamp
		{
			get
			{
				return this._IndexTimeStamp;
			}
			set
			{
				if ((this._IndexTimeStamp != value))
				{
					this.OnIndexTimeStampChanging(value);
					this.SendPropertyChanging();
					this._IndexTimeStamp = value;
					this.SendPropertyChanged("IndexTimeStamp");
					this.OnIndexTimeStampChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastIndex", DbType="Float")]
		public System.Nullable<double> LastIndex
		{
			get
			{
				return this._LastIndex;
			}
			set
			{
				if ((this._LastIndex != value))
				{
					this.OnLastIndexChanging(value);
					this.SendPropertyChanging();
					this._LastIndex = value;
					this.SendPropertyChanged("LastIndex");
					this.OnLastIndexChanged();
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
