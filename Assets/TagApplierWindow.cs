using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Oculus.Interaction;

public class TagApplierWindow : EditorWindow
{
    private enum Tab
    {
        TagApplier,
        TagFilter
    }

    private Tab currentTab = Tab.TagApplier;
    private GameObject[] objectsToTag = new GameObject[0];
    private List<string> tagsToApply = new List<string>();
    private List<string> requireTags = new List<string>();
    private List<string> excludeTags = new List<string>();

    private Vector2 scrollPosition;

    [MenuItem("Tools/Tag Applier")]
    private static void OpenWindow()
    {
        TagApplierWindow window = GetWindow<TagApplierWindow>();
        window.titleContent = new GUIContent("Tag Applier");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Tag Manager", EditorStyles.boldLabel);

        currentTab = (Tab)GUILayout.Toolbar((int)currentTab, new string[] { "Tag Applier", "Tag Filter" });

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("Specify the objects and tags below.", MessageType.Info);

        EditorGUILayout.Space();

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        if (currentTab == Tab.TagApplier)
        {
            DrawTagApplier();
        }
        else if (currentTab == Tab.TagFilter)
        {
            DrawTagFilter();
        }

        EditorGUILayout.EndScrollView();
    }

    private void DrawTagApplier()
    {
        EditorGUILayout.LabelField("Objects to Tag", EditorStyles.boldLabel);

        int objectsCount = EditorGUILayout.IntField("Size", objectsToTag != null ? objectsToTag.Length : 0);

        if (objectsCount < 0)
            objectsCount = 0;

        if (objectsToTag == null || objectsToTag.Length != objectsCount)
        {
            GameObject[] newObjectsToTag = new GameObject[objectsCount];
            for (int i = 0; i < objectsCount; i++)
            {
                if (i < objectsToTag.Length)
                {
                    newObjectsToTag[i] = objectsToTag[i];
                }
                else
                {
                    newObjectsToTag[i] = null;
                }
            }
            objectsToTag = newObjectsToTag;
        }

        for (int i = 0; i < objectsCount; i++)
        {
            objectsToTag[i] = EditorGUILayout.ObjectField($"Object {i}", objectsToTag[i], typeof(GameObject), true) as GameObject;
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Tags to Apply", EditorStyles.boldLabel);

        int tagsCount = EditorGUILayout.IntField("Size", tagsToApply.Count);

        if (tagsCount < 0)
            tagsCount = 0;

        if (tagsToApply.Count != tagsCount)
        {
            while (tagsToApply.Count < tagsCount)
            {
                tagsToApply.Add(string.Empty);
            }
            while (tagsToApply.Count > tagsCount)
            {
                tagsToApply.RemoveAt(tagsToApply.Count - 1);
            }
        }

        for (int i = 0; i < tagsCount; i++)
        {
            tagsToApply[i] = EditorGUILayout.TextField($"Tag {i}", tagsToApply[i]);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Apply Tags"))
        {
            ApplyTags();
        }
    }

    private void DrawTagFilter()
    {
        EditorGUILayout.LabelField("Objects to Filter", EditorStyles.boldLabel);

        int objectsCount = EditorGUILayout.IntField("Size", objectsToTag != null ? objectsToTag.Length : 0);

        if (objectsCount < 0)
            objectsCount = 0;

        if (objectsToTag == null || objectsToTag.Length != objectsCount)
        {
            GameObject[] newObjectsToTag = new GameObject[objectsCount];
            for (int i = 0; i < objectsCount; i++)
            {
                if (i < objectsToTag.Length)
                {
                    newObjectsToTag[i] = objectsToTag[i];
                }
                else
                {
                    newObjectsToTag[i] = null;
                }
            }
            objectsToTag = newObjectsToTag;
        }

        for (int i = 0; i < objectsCount; i++)
        {
            objectsToTag[i] = EditorGUILayout.ObjectField($"Object {i}", objectsToTag[i], typeof(GameObject), true) as GameObject;
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Require Tags", EditorStyles.boldLabel);

        int requireTagsCount = EditorGUILayout.IntField("Size", requireTags.Count);

        if (requireTagsCount < 0)
            requireTagsCount = 0;

        if (requireTags.Count != requireTagsCount)
        {
            while (requireTags.Count < requireTagsCount)
            {
                requireTags.Add(string.Empty);
            }
            while (requireTags.Count > requireTagsCount)
            {
                requireTags.RemoveAt(requireTags.Count - 1);
            }
        }

        for (int i = 0; i < requireTagsCount; i++)
        {
            requireTags[i] = EditorGUILayout.TextField($"Require Tag {i}", requireTags[i]);
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Exclude Tags", EditorStyles.boldLabel);

        int excludeTagsCount = EditorGUILayout.IntField("Size", excludeTags.Count);

        if (excludeTagsCount < 0)
            excludeTagsCount = 0;

        if (excludeTags.Count != excludeTagsCount)
        {
            while (excludeTags.Count < excludeTagsCount)
            {
                excludeTags.Add(string.Empty);
            }
            while (excludeTags.Count > excludeTagsCount)
            {
                excludeTags.RemoveAt(excludeTags.Count - 1);
            }
        }

        for (int i = 0; i < excludeTagsCount; i++)
        {
            excludeTags[i] = EditorGUILayout.TextField($"Exclude Tag {i}", excludeTags[i]);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Filter Objects"))
        {
            FilterObjects();
        }
    }

    private void ApplyTags()
    {
        foreach (GameObject obj in objectsToTag)
        {
            if (obj == null)
                continue;

            TagSet tagSet = obj.GetComponent<TagSet>();
            if (tagSet == null)
            {
                tagSet = obj.AddComponent<TagSet>();
            }

            // Inject Optional Tags
            tagSet.InjectOptionalTags(tagsToApply);
        }
    }


    private void FilterObjects()
    {
        foreach (GameObject obj in objectsToTag)
        {
            if (obj == null)
                continue;

            TagSetFilter tagSetFilter = obj.GetComponent<TagSetFilter>();
            if (tagSetFilter == null)
            {
                tagSetFilter = obj.AddComponent<TagSetFilter>();
            }

            // Inject Require Tags
            tagSetFilter.InjectOptionalRequireTags(requireTags.ToArray());

            // Inject Exclude Tags
            tagSetFilter.InjectOptionalExcludeTags(excludeTags.ToArray());
        }
    }

}
