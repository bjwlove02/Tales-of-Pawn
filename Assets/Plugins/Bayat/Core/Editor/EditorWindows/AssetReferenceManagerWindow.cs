﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Bayat.Core.EditorWindows
{

    public class AssetReferenceManagerWindow : EditorWindowWrapper
    {

        public const int ItemsPerPage = 17;

        protected Vector2 scrollPosition;
        protected int removeIndex = -1;

        protected int itemsCount = 0;
        protected int pageCount = 0;
        protected int pageIndex = 0;
        protected int offsetIndex = 0;

        [MenuItem("Window/Bayat/Core/Asset Reference Manager")]
        private static void Initialize()
        {
            var window = new AssetReferenceManagerWindow();
            window.Show();
        }

        protected override void ConfigureWindow()
        {
            window.titleContent = new GUIContent("Asset Reference Manager");
            window.minSize = window.maxSize = new Vector2(630, 400);
        }

        public new void Show()
        {
            if (window == null)
            {
                ShowUtility();
                window.Center();
            }
            else
            {
                window.Focus();
            }
        }

        public override void OnGUI()
        {
            GUILayout.Label("Asset Reference <b>Manager</b>", Styles.CenteredLargeLabel);
            AssetReferenceResolver referenceResolver = AssetReferenceResolver.Current;

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Reset", EditorStyles.toolbarButton))
            {
                if (EditorUtility.DisplayDialog("Reset Asset Reference Database?", "This action will reset whole asset reference database and used GUIDs which makes the saved GUIDs obsolote, so there will be problems when loading previously saved data using this database.\n\nProceed at your own risk.", "Reset", "Cancel"))
                {
                    referenceResolver.Guids.Clear();
                    referenceResolver.Dependencies.Clear();
                    referenceResolver.Reset();
                }
            }

            if (GUILayout.Button("Collect Project Dependencies", EditorStyles.toolbarButton))
            {
                referenceResolver.CollectProjectDependencies();
            }
            if (GUILayout.Button("Collect Active Scene Dependencies", EditorStyles.toolbarButton))
            {
                referenceResolver.CollectActiveSceneDependencies();
            }

            EditorGUILayout.EndHorizontal();

            this.scrollPosition = EditorGUILayout.BeginScrollView(this.scrollPosition);

            if (this.removeIndex != -1)
            {
                referenceResolver.Guids.RemoveAt(this.removeIndex);
                referenceResolver.Dependencies.RemoveAt(this.removeIndex);
                this.removeIndex = -1;
            }

            if (referenceResolver.Guids.Count == 0)
            {
                GUILayout.Label("There are no references in the database", EditorStyles.centeredGreyMiniLabel);
            }

            this.itemsCount = referenceResolver.Guids.Count;
            this.pageCount = (this.itemsCount + ItemsPerPage - 1) / ItemsPerPage;
            this.offsetIndex = this.pageIndex * ItemsPerPage;

            for (int i = this.offsetIndex; i - this.offsetIndex < ItemsPerPage; i++)
            {
                if (i < referenceResolver.Guids.Count)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.SelectableLabel(referenceResolver.Guids[i], EditorStyles.textField, GUILayout.Height(16));
                    referenceResolver.Dependencies[i] = EditorGUILayout.ObjectField(referenceResolver.Dependencies[i], typeof(UnityEngine.Object), false);
                    if (GUILayout.Button("Remove", EditorStyles.miniButtonRight))
                    {
                        if (EditorUtility.DisplayDialog("Remove Reference?", "This action will remove the asset reference from the database and used GUID which makes the saved GUID obsolote, so there will be problems when loading previously saved data using this database.\n\nProceed at your own risk.", "Remove", "Cancel"))
                        {
                            this.removeIndex = i;
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();

            GUILayout.FlexibleSpace();

            // Pagination
            EditorGUILayout.BeginHorizontal();

            GUILayout.FlexibleSpace();

            bool hasPrevPage = this.pageIndex - 1 >= 0;
            EditorGUI.BeginDisabledGroup(!hasPrevPage);
            if (GUILayout.Button("< Prev", EditorStyles.miniButton, GUILayout.Width(150)))
            {
                this.pageIndex--;
            }
            EditorGUI.EndDisabledGroup();

            GUI.SetNextControlName("PageIndex");
            EditorGUI.BeginChangeCheck();
            this.pageIndex = EditorGUILayout.IntField(this.pageIndex + 1, EditorStyles.numberField, GUILayout.Width(32)) - 1;
            if (EditorGUI.EndChangeCheck())
            {
                EditorGUI.FocusTextInControl("PageIndex");
                GUI.FocusControl("PageIndex");
            }
            GUILayout.Label("/" + this.pageCount.ToString());

            bool hasNextPage = this.pageIndex + 1 < this.pageCount;
            EditorGUI.BeginDisabledGroup(!hasNextPage);
            if (GUILayout.Button("Next >", EditorStyles.miniButton, GUILayout.Width(150)))
            {
                this.pageIndex++;
            }
            EditorGUI.EndDisabledGroup();

            GUILayout.FlexibleSpace();

            EditorGUILayout.EndHorizontal();

            if (this.pageIndex < 0)
            {
                this.pageIndex = 0;
                EditorGUI.FocusTextInControl("PageIndex");
                GUI.FocusControl("PageIndex");
            }
            else if (this.pageIndex >= this.pageCount)
            {
                this.pageIndex = this.pageCount - 1;
                EditorGUI.FocusTextInControl("PageIndex");
                GUI.FocusControl("PageIndex");
            }

            GUILayout.Label("Made with ❤️ by Bayat", EditorStyles.centeredGreyMiniLabel);
        }

        public static class Styles
        {
            static Styles()
            {
                CenteredLargeLabel = new GUIStyle(EditorStyles.largeLabel);
                CenteredLargeLabel.alignment = TextAnchor.MiddleCenter;
                CenteredLargeLabel.richText = true;
            }

            public static readonly GUIStyle CenteredLargeLabel;

        }

    }

}