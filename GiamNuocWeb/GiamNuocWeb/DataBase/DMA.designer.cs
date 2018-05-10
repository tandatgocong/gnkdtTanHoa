﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiamNuocWeb.DataBase
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
	public partial class DMADataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertg_GhiChu(g_GhiChu instance);
    partial void Updateg_GhiChu(g_GhiChu instance);
    partial void Deleteg_GhiChu(g_GhiChu instance);
    partial void Insertt_User(t_User instance);
    partial void Updatet_User(t_User instance);
    partial void Deletet_User(t_User instance);
    partial void Insertg_ThongTinDHT(g_ThongTinDHT instance);
    partial void Updateg_ThongTinDHT(g_ThongTinDHT instance);
    partial void Deleteg_ThongTinDHT(g_ThongTinDHT instance);
    #endregion
		
		public DMADataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["tanhoaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DMADataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DMADataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DMADataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DMADataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<g_GhiChu> g_GhiChus
		{
			get
			{
				return this.GetTable<g_GhiChu>();
			}
		}
		
		public System.Data.Linq.Table<t_User> t_Users
		{
			get
			{
				return this.GetTable<t_User>();
			}
		}
		
		public System.Data.Linq.Table<g_ThongTinDHT> g_ThongTinDHTs
		{
			get
			{
				return this.GetTable<g_ThongTinDHT>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.g_GhiChu")]
	public partial class g_GhiChu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _MaDMA;
		
		private string _NOIDUNG;
		
		private System.Nullable<System.DateTime> _CREATEDATE;
		
		private string _CREATEBY;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnMaDMAChanging(string value);
    partial void OnMaDMAChanged();
    partial void OnNOIDUNGChanging(string value);
    partial void OnNOIDUNGChanged();
    partial void OnCREATEDATEChanging(System.Nullable<System.DateTime> value);
    partial void OnCREATEDATEChanged();
    partial void OnCREATEBYChanging(string value);
    partial void OnCREATEBYChanged();
    #endregion
		
		public g_GhiChu()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDMA", DbType="VarChar(20)")]
		public string MaDMA
		{
			get
			{
				return this._MaDMA;
			}
			set
			{
				if ((this._MaDMA != value))
				{
					this.OnMaDMAChanging(value);
					this.SendPropertyChanging();
					this._MaDMA = value;
					this.SendPropertyChanged("MaDMA");
					this.OnMaDMAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOIDUNG", DbType="NVarChar(MAX)")]
		public string NOIDUNG
		{
			get
			{
				return this._NOIDUNG;
			}
			set
			{
				if ((this._NOIDUNG != value))
				{
					this.OnNOIDUNGChanging(value);
					this.SendPropertyChanging();
					this._NOIDUNG = value;
					this.SendPropertyChanged("NOIDUNG");
					this.OnNOIDUNGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEDATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> CREATEDATE
		{
			get
			{
				return this._CREATEDATE;
			}
			set
			{
				if ((this._CREATEDATE != value))
				{
					this.OnCREATEDATEChanging(value);
					this.SendPropertyChanging();
					this._CREATEDATE = value;
					this.SendPropertyChanged("CREATEDATE");
					this.OnCREATEDATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CREATEBY", DbType="NVarChar(100)")]
		public string CREATEBY
		{
			get
			{
				return this._CREATEBY;
			}
			set
			{
				if ((this._CREATEBY != value))
				{
					this.OnCREATEBYChanging(value);
					this.SendPropertyChanging();
					this._CREATEBY = value;
					this.SendPropertyChanged("CREATEBY");
					this.OnCREATEBYChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.t_Users")]
	public partial class t_User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Username;
		
		private string _Password;
		
		private string _Salt;
		
		private string _StaffId;
		
		private string _ConsumerId;
		
		private string _Email;
		
		private string _Role;
		
		private System.Nullable<bool> _Active;
		
		private System.Nullable<System.DateTime> _TimeStamp;
		
		private string _Ip;
		
		private System.Nullable<int> _LoginTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnSaltChanging(string value);
    partial void OnSaltChanged();
    partial void OnStaffIdChanging(string value);
    partial void OnStaffIdChanged();
    partial void OnConsumerIdChanging(string value);
    partial void OnConsumerIdChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnRoleChanging(string value);
    partial void OnRoleChanged();
    partial void OnActiveChanging(System.Nullable<bool> value);
    partial void OnActiveChanged();
    partial void OnTimeStampChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeStampChanged();
    partial void OnIpChanging(string value);
    partial void OnIpChanged();
    partial void OnLoginTimeChanging(System.Nullable<int> value);
    partial void OnLoginTimeChanged();
    #endregion
		
		public t_User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(250) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Salt", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Salt
		{
			get
			{
				return this._Salt;
			}
			set
			{
				if ((this._Salt != value))
				{
					this.OnSaltChanging(value);
					this.SendPropertyChanging();
					this._Salt = value;
					this.SendPropertyChanged("Salt");
					this.OnSaltChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StaffId", DbType="VarChar(50)")]
		public string StaffId
		{
			get
			{
				return this._StaffId;
			}
			set
			{
				if ((this._StaffId != value))
				{
					this.OnStaffIdChanging(value);
					this.SendPropertyChanging();
					this._StaffId = value;
					this.SendPropertyChanged("StaffId");
					this.OnStaffIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConsumerId", DbType="VarChar(50)")]
		public string ConsumerId
		{
			get
			{
				return this._ConsumerId;
			}
			set
			{
				if ((this._ConsumerId != value))
				{
					this.OnConsumerIdChanging(value);
					this.SendPropertyChanging();
					this._ConsumerId = value;
					this.SendPropertyChanged("ConsumerId");
					this.OnConsumerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Role", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Role
		{
			get
			{
				return this._Role;
			}
			set
			{
				if ((this._Role != value))
				{
					this.OnRoleChanging(value);
					this.SendPropertyChanging();
					this._Role = value;
					this.SendPropertyChanged("Role");
					this.OnRoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit")]
		public System.Nullable<bool> Active
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ip", DbType="NVarChar(50)")]
		public string Ip
		{
			get
			{
				return this._Ip;
			}
			set
			{
				if ((this._Ip != value))
				{
					this.OnIpChanging(value);
					this.SendPropertyChanging();
					this._Ip = value;
					this.SendPropertyChanged("Ip");
					this.OnIpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoginTime", DbType="Int")]
		public System.Nullable<int> LoginTime
		{
			get
			{
				return this._LoginTime;
			}
			set
			{
				if ((this._LoginTime != value))
				{
					this.OnLoginTimeChanging(value);
					this.SendPropertyChanging();
					this._LoginTime = value;
					this.SendPropertyChanged("LoginTime");
					this.OnLoginTimeChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.g_ThongTinDHT")]
	public partial class g_ThongTinDHT : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<double> _STT;
		
		private string _MaDMA;
		
		private string _ViTri;
		
		private string _Phuong;
		
		private string _Quan;
		
		private System.Nullable<bool> _PRV;
		
		private string _CoDHN;
		
		private string _Hieu;
		
		private string _PinNguon;
		
		private string _ThietBi;
		
		private string _HamDHT;
		
		private string _TuCelloMK4;
		
		private System.Nullable<bool> _StatusDHT;
		
		private string _TinhTrangDH;
		
		private string _TinhTrangBlogger;
		
		private string _TinhTrangPRV;
		
		private string _GhiChu;
		
		private string _SoSIM;
		
		private string _SoSeri;
		
		private string _SoGon;
		
		private string _ChannelId;
		
		private string _ChannelOut;
		
		private string _ChannelCMP;
		
		private string _StatusCMP;
		
		private string _DHTLat;
		
		private string _DHTLng;
		
		private string _Img;
		
		private System.Nullable<System.DateTime> _ModifyDate;
		
		private string _ModifyBy;
		
		private string _CMPLat;
		
		private string _CMPLng;
		
		private string _ViTriCMP;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSTTChanging(System.Nullable<double> value);
    partial void OnSTTChanged();
    partial void OnMaDMAChanging(string value);
    partial void OnMaDMAChanged();
    partial void OnViTriChanging(string value);
    partial void OnViTriChanged();
    partial void OnPhuongChanging(string value);
    partial void OnPhuongChanged();
    partial void OnQuanChanging(string value);
    partial void OnQuanChanged();
    partial void OnPRVChanging(System.Nullable<bool> value);
    partial void OnPRVChanged();
    partial void OnCoDHNChanging(string value);
    partial void OnCoDHNChanged();
    partial void OnHieuChanging(string value);
    partial void OnHieuChanged();
    partial void OnPinNguonChanging(string value);
    partial void OnPinNguonChanged();
    partial void OnThietBiChanging(string value);
    partial void OnThietBiChanged();
    partial void OnHamDHTChanging(string value);
    partial void OnHamDHTChanged();
    partial void OnTuCelloMK4Changing(string value);
    partial void OnTuCelloMK4Changed();
    partial void OnStatusDHTChanging(System.Nullable<bool> value);
    partial void OnStatusDHTChanged();
    partial void OnTinhTrangDHChanging(string value);
    partial void OnTinhTrangDHChanged();
    partial void OnTinhTrangBloggerChanging(string value);
    partial void OnTinhTrangBloggerChanged();
    partial void OnTinhTrangPRVChanging(string value);
    partial void OnTinhTrangPRVChanged();
    partial void OnGhiChuChanging(string value);
    partial void OnGhiChuChanged();
    partial void OnSoSIMChanging(string value);
    partial void OnSoSIMChanged();
    partial void OnSoSeriChanging(string value);
    partial void OnSoSeriChanged();
    partial void OnSoGonChanging(string value);
    partial void OnSoGonChanged();
    partial void OnChannelIdChanging(string value);
    partial void OnChannelIdChanged();
    partial void OnChannelOutChanging(string value);
    partial void OnChannelOutChanged();
    partial void OnChannelCMPChanging(string value);
    partial void OnChannelCMPChanged();
    partial void OnStatusCMPChanging(string value);
    partial void OnStatusCMPChanged();
    partial void OnDHTLatChanging(string value);
    partial void OnDHTLatChanged();
    partial void OnDHTLngChanging(string value);
    partial void OnDHTLngChanged();
    partial void OnImgChanging(string value);
    partial void OnImgChanged();
    partial void OnModifyDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifyDateChanged();
    partial void OnModifyByChanging(string value);
    partial void OnModifyByChanged();
    partial void OnCMPLatChanging(string value);
    partial void OnCMPLatChanged();
    partial void OnCMPLngChanging(string value);
    partial void OnCMPLngChanged();
    partial void OnViTriCMPChanging(string value);
    partial void OnViTriCMPChanged();
    #endregion
		
		public g_ThongTinDHT()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STT", DbType="Float")]
		public System.Nullable<double> STT
		{
			get
			{
				return this._STT;
			}
			set
			{
				if ((this._STT != value))
				{
					this.OnSTTChanging(value);
					this.SendPropertyChanging();
					this._STT = value;
					this.SendPropertyChanged("STT");
					this.OnSTTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaDMA", DbType="NVarChar(255) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaDMA
		{
			get
			{
				return this._MaDMA;
			}
			set
			{
				if ((this._MaDMA != value))
				{
					this.OnMaDMAChanging(value);
					this.SendPropertyChanging();
					this._MaDMA = value;
					this.SendPropertyChanged("MaDMA");
					this.OnMaDMAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViTri", DbType="NVarChar(255)")]
		public string ViTri
		{
			get
			{
				return this._ViTri;
			}
			set
			{
				if ((this._ViTri != value))
				{
					this.OnViTriChanging(value);
					this.SendPropertyChanging();
					this._ViTri = value;
					this.SendPropertyChanged("ViTri");
					this.OnViTriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phuong", DbType="NVarChar(255)")]
		public string Phuong
		{
			get
			{
				return this._Phuong;
			}
			set
			{
				if ((this._Phuong != value))
				{
					this.OnPhuongChanging(value);
					this.SendPropertyChanging();
					this._Phuong = value;
					this.SendPropertyChanged("Phuong");
					this.OnPhuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quan", DbType="NVarChar(255)")]
		public string Quan
		{
			get
			{
				return this._Quan;
			}
			set
			{
				if ((this._Quan != value))
				{
					this.OnQuanChanging(value);
					this.SendPropertyChanging();
					this._Quan = value;
					this.SendPropertyChanged("Quan");
					this.OnQuanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRV", DbType="Bit")]
		public System.Nullable<bool> PRV
		{
			get
			{
				return this._PRV;
			}
			set
			{
				if ((this._PRV != value))
				{
					this.OnPRVChanging(value);
					this.SendPropertyChanging();
					this._PRV = value;
					this.SendPropertyChanged("PRV");
					this.OnPRVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CoDHN", DbType="NVarChar(255)")]
		public string CoDHN
		{
			get
			{
				return this._CoDHN;
			}
			set
			{
				if ((this._CoDHN != value))
				{
					this.OnCoDHNChanging(value);
					this.SendPropertyChanging();
					this._CoDHN = value;
					this.SendPropertyChanged("CoDHN");
					this.OnCoDHNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hieu", DbType="NVarChar(255)")]
		public string Hieu
		{
			get
			{
				return this._Hieu;
			}
			set
			{
				if ((this._Hieu != value))
				{
					this.OnHieuChanging(value);
					this.SendPropertyChanging();
					this._Hieu = value;
					this.SendPropertyChanged("Hieu");
					this.OnHieuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PinNguon", DbType="NVarChar(255)")]
		public string PinNguon
		{
			get
			{
				return this._PinNguon;
			}
			set
			{
				if ((this._PinNguon != value))
				{
					this.OnPinNguonChanging(value);
					this.SendPropertyChanging();
					this._PinNguon = value;
					this.SendPropertyChanged("PinNguon");
					this.OnPinNguonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThietBi", DbType="NVarChar(255)")]
		public string ThietBi
		{
			get
			{
				return this._ThietBi;
			}
			set
			{
				if ((this._ThietBi != value))
				{
					this.OnThietBiChanging(value);
					this.SendPropertyChanging();
					this._ThietBi = value;
					this.SendPropertyChanged("ThietBi");
					this.OnThietBiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HamDHT", DbType="NVarChar(255)")]
		public string HamDHT
		{
			get
			{
				return this._HamDHT;
			}
			set
			{
				if ((this._HamDHT != value))
				{
					this.OnHamDHTChanging(value);
					this.SendPropertyChanging();
					this._HamDHT = value;
					this.SendPropertyChanged("HamDHT");
					this.OnHamDHTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuCelloMK4", DbType="NVarChar(255)")]
		public string TuCelloMK4
		{
			get
			{
				return this._TuCelloMK4;
			}
			set
			{
				if ((this._TuCelloMK4 != value))
				{
					this.OnTuCelloMK4Changing(value);
					this.SendPropertyChanging();
					this._TuCelloMK4 = value;
					this.SendPropertyChanged("TuCelloMK4");
					this.OnTuCelloMK4Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusDHT", DbType="Bit")]
		public System.Nullable<bool> StatusDHT
		{
			get
			{
				return this._StatusDHT;
			}
			set
			{
				if ((this._StatusDHT != value))
				{
					this.OnStatusDHTChanging(value);
					this.SendPropertyChanging();
					this._StatusDHT = value;
					this.SendPropertyChanged("StatusDHT");
					this.OnStatusDHTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinhTrangDH", DbType="NVarChar(255)")]
		public string TinhTrangDH
		{
			get
			{
				return this._TinhTrangDH;
			}
			set
			{
				if ((this._TinhTrangDH != value))
				{
					this.OnTinhTrangDHChanging(value);
					this.SendPropertyChanging();
					this._TinhTrangDH = value;
					this.SendPropertyChanged("TinhTrangDH");
					this.OnTinhTrangDHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinhTrangBlogger", DbType="NVarChar(255)")]
		public string TinhTrangBlogger
		{
			get
			{
				return this._TinhTrangBlogger;
			}
			set
			{
				if ((this._TinhTrangBlogger != value))
				{
					this.OnTinhTrangBloggerChanging(value);
					this.SendPropertyChanging();
					this._TinhTrangBlogger = value;
					this.SendPropertyChanged("TinhTrangBlogger");
					this.OnTinhTrangBloggerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TinhTrangPRV", DbType="NVarChar(255)")]
		public string TinhTrangPRV
		{
			get
			{
				return this._TinhTrangPRV;
			}
			set
			{
				if ((this._TinhTrangPRV != value))
				{
					this.OnTinhTrangPRVChanging(value);
					this.SendPropertyChanging();
					this._TinhTrangPRV = value;
					this.SendPropertyChanged("TinhTrangPRV");
					this.OnTinhTrangPRVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GhiChu", DbType="NVarChar(255)")]
		public string GhiChu
		{
			get
			{
				return this._GhiChu;
			}
			set
			{
				if ((this._GhiChu != value))
				{
					this.OnGhiChuChanging(value);
					this.SendPropertyChanging();
					this._GhiChu = value;
					this.SendPropertyChanged("GhiChu");
					this.OnGhiChuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoSIM", DbType="NVarChar(50)")]
		public string SoSIM
		{
			get
			{
				return this._SoSIM;
			}
			set
			{
				if ((this._SoSIM != value))
				{
					this.OnSoSIMChanging(value);
					this.SendPropertyChanging();
					this._SoSIM = value;
					this.SendPropertyChanged("SoSIM");
					this.OnSoSIMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoSeri", DbType="NVarChar(50)")]
		public string SoSeri
		{
			get
			{
				return this._SoSeri;
			}
			set
			{
				if ((this._SoSeri != value))
				{
					this.OnSoSeriChanging(value);
					this.SendPropertyChanging();
					this._SoSeri = value;
					this.SendPropertyChanged("SoSeri");
					this.OnSoSeriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoGon", DbType="NVarChar(50)")]
		public string SoGon
		{
			get
			{
				return this._SoGon;
			}
			set
			{
				if ((this._SoGon != value))
				{
					this.OnSoGonChanging(value);
					this.SendPropertyChanging();
					this._SoGon = value;
					this.SendPropertyChanged("SoGon");
					this.OnSoGonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelId", DbType="VarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelOut", DbType="VarChar(50)")]
		public string ChannelOut
		{
			get
			{
				return this._ChannelOut;
			}
			set
			{
				if ((this._ChannelOut != value))
				{
					this.OnChannelOutChanging(value);
					this.SendPropertyChanging();
					this._ChannelOut = value;
					this.SendPropertyChanged("ChannelOut");
					this.OnChannelOutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChannelCMP", DbType="VarChar(50)")]
		public string ChannelCMP
		{
			get
			{
				return this._ChannelCMP;
			}
			set
			{
				if ((this._ChannelCMP != value))
				{
					this.OnChannelCMPChanging(value);
					this.SendPropertyChanging();
					this._ChannelCMP = value;
					this.SendPropertyChanged("ChannelCMP");
					this.OnChannelCMPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StatusCMP", DbType="VarChar(50)")]
		public string StatusCMP
		{
			get
			{
				return this._StatusCMP;
			}
			set
			{
				if ((this._StatusCMP != value))
				{
					this.OnStatusCMPChanging(value);
					this.SendPropertyChanging();
					this._StatusCMP = value;
					this.SendPropertyChanged("StatusCMP");
					this.OnStatusCMPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DHTLat", DbType="NVarChar(50)")]
		public string DHTLat
		{
			get
			{
				return this._DHTLat;
			}
			set
			{
				if ((this._DHTLat != value))
				{
					this.OnDHTLatChanging(value);
					this.SendPropertyChanging();
					this._DHTLat = value;
					this.SendPropertyChanged("DHTLat");
					this.OnDHTLatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DHTLng", DbType="NVarChar(50)")]
		public string DHTLng
		{
			get
			{
				return this._DHTLng;
			}
			set
			{
				if ((this._DHTLng != value))
				{
					this.OnDHTLngChanging(value);
					this.SendPropertyChanging();
					this._DHTLng = value;
					this.SendPropertyChanged("DHTLng");
					this.OnDHTLngChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Img", DbType="NVarChar(MAX)")]
		public string Img
		{
			get
			{
				return this._Img;
			}
			set
			{
				if ((this._Img != value))
				{
					this.OnImgChanging(value);
					this.SendPropertyChanging();
					this._Img = value;
					this.SendPropertyChanged("Img");
					this.OnImgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifyDate
		{
			get
			{
				return this._ModifyDate;
			}
			set
			{
				if ((this._ModifyDate != value))
				{
					this.OnModifyDateChanging(value);
					this.SendPropertyChanging();
					this._ModifyDate = value;
					this.SendPropertyChanged("ModifyDate");
					this.OnModifyDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifyBy", DbType="NVarChar(50)")]
		public string ModifyBy
		{
			get
			{
				return this._ModifyBy;
			}
			set
			{
				if ((this._ModifyBy != value))
				{
					this.OnModifyByChanging(value);
					this.SendPropertyChanging();
					this._ModifyBy = value;
					this.SendPropertyChanged("ModifyBy");
					this.OnModifyByChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CMPLat", DbType="NVarChar(50)")]
		public string CMPLat
		{
			get
			{
				return this._CMPLat;
			}
			set
			{
				if ((this._CMPLat != value))
				{
					this.OnCMPLatChanging(value);
					this.SendPropertyChanging();
					this._CMPLat = value;
					this.SendPropertyChanged("CMPLat");
					this.OnCMPLatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CMPLng", DbType="NVarChar(50)")]
		public string CMPLng
		{
			get
			{
				return this._CMPLng;
			}
			set
			{
				if ((this._CMPLng != value))
				{
					this.OnCMPLngChanging(value);
					this.SendPropertyChanging();
					this._CMPLng = value;
					this.SendPropertyChanged("CMPLng");
					this.OnCMPLngChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViTriCMP", DbType="NVarChar(255)")]
		public string ViTriCMP
		{
			get
			{
				return this._ViTriCMP;
			}
			set
			{
				if ((this._ViTriCMP != value))
				{
					this.OnViTriCMPChanging(value);
					this.SendPropertyChanging();
					this._ViTriCMP = value;
					this.SendPropertyChanged("ViTriCMP");
					this.OnViTriCMPChanged();
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
