//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;
using System.Globalization;

namespace Google2u
{
	[System.Serializable]
	public class Sheet1Row : IGoogle2uRow
	{
		public string _Name;
		public Sheet1Row(string __GOOGLEFU_ID, string __Name) 
		{
			_Name = __Name.Trim();
		}

		public int Length { get { return 1; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _Name.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID )
			{
				case "_Name":
					ret = _Name.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Name" + " : " + _Name.ToString() + "} ";
			return ret;
		}
	}
	public class Sheet1 :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			HYPE
		};
		public string [] rowNames = {
			"HYPE"
		};
		public System.Collections.Generic.List<Sheet1Row> Rows = new System.Collections.Generic.List<Sheet1Row>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new Sheet1Row(input[0],input[1]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public Sheet1Row GetRow(rowIds in_RowID)
		{
			Sheet1Row ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public Sheet1Row GetRow(string in_RowString)
		{
			Sheet1Row ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
