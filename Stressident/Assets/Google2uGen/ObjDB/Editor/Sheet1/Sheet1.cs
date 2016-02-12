using UnityEngine;
using UnityEditor;

namespace Google2u
{
	[CustomEditor(typeof(Sheet1))]
	public class Sheet1Editor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			Sheet1 s = target as Sheet1;
			Sheet1Row r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Name", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._Name );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Yes", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._Yes );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_No", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._No );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "_Maybe", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._Maybe );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
