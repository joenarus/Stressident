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
	public class QuestionsRow : IGoogle2uRow
	{
		public string _Name;
		public int _Yes;
		public int _No;
		public int _Maybe;
		public QuestionsRow(string __GOOGLEFU_ID, string __Name, string __Yes, string __No, string __Maybe) 
		{
			_Name = __Name.Trim();
			{
			int res;
				if(int.TryParse(__Yes, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Yes = res;
				else
					Debug.LogError("Failed To Convert _Yes string: "+ __Yes +" to int");
			}
			{
			int res;
				if(int.TryParse(__No, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_No = res;
				else
					Debug.LogError("Failed To Convert _No string: "+ __No +" to int");
			}
			{
			int res;
				if(int.TryParse(__Maybe, NumberStyles.Any, CultureInfo.InvariantCulture, out res))
					_Maybe = res;
				else
					Debug.LogError("Failed To Convert _Maybe string: "+ __Maybe +" to int");
			}
		}

		public int Length { get { return 4; } }

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
				case 1:
					ret = _Yes.ToString();
					break;
				case 2:
					ret = _No.ToString();
					break;
				case 3:
					ret = _Maybe.ToString();
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
				case "_Yes":
					ret = _Yes.ToString();
					break;
				case "_No":
					ret = _No.ToString();
					break;
				case "_Maybe":
					ret = _Maybe.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "_Name" + " : " + _Name.ToString() + "} ";
			ret += "{" + "_Yes" + " : " + _Yes.ToString() + "} ";
			ret += "{" + "_No" + " : " + _No.ToString() + "} ";
			ret += "{" + "_Maybe" + " : " + _Maybe.ToString() + "} ";
			return ret;
		}
	}
	public class Questions :  Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds {
			ID_Q1, ID_Q2, ID_Q3, ID_Q4, ID_Q5, ID_Q6, ID_Q7, ID_Q8, ID_Q9, ID_Q10
		};
		public string [] rowNames = {
			"ID_Q1", "ID_Q2", "ID_Q3", "ID_Q4", "ID_Q5", "ID_Q6", "ID_Q7", "ID_Q8", "ID_Q9", "ID_Q10"
		};
		public System.Collections.Generic.List<QuestionsRow> Rows = new System.Collections.Generic.List<QuestionsRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new QuestionsRow(input[0],input[1],input[2],input[3],input[4]));
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
		public QuestionsRow GetRow(rowIds in_RowID)
		{
			QuestionsRow ret = null;
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
		public QuestionsRow GetRow(string in_RowString)
		{
			QuestionsRow ret = null;
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
