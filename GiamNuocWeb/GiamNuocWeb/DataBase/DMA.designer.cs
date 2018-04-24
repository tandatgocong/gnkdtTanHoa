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
		
		public System.Data.Linq.Table<g_ThongTinDHT> g_ThongTinDHTs
		{
			get
			{
				return this.GetTable<g_ThongTinDHT>();
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
