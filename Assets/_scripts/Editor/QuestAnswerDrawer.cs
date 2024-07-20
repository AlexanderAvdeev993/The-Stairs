using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(QuestAnswer))]
public class QuestAnswerDrawer : PropertyDrawer
{
    private const int GridSize = 4;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var questType = (QuestType)property.FindPropertyRelative("_questType").enumValueIndex;

        float baseHeight = EditorGUIUtility.singleLineHeight;
        float additionalHeight = 0;

        switch (questType)
        {
            case QuestType.ButtonQuest:
                additionalHeight = EditorGUIUtility.singleLineHeight * GridSize; // 6 rows * single line height
                break;
            case QuestType.MathQuest:
                additionalHeight = EditorGUIUtility.singleLineHeight;
                break;
        }

        return baseHeight + additionalHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var questTypeProperty = property.FindPropertyRelative("_questType");
        var buttonQuestProperty = property.FindPropertyRelative("ButtonQuest");
        var intQuestProperty = property.FindPropertyRelative("IntQuest");

        EditorGUI.PropertyField(
            new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
            questTypeProperty);

        EditorGUI.indentLevel++;

        var questType = (QuestType)questTypeProperty.enumValueIndex;

        switch (questType)
        {
            case QuestType.ButtonQuest:              
                DrawButtonQuestGrid(position, buttonQuestProperty);
                break;

            case QuestType.MathQuest:
                EditorGUI.PropertyField(
                    new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight),
                    intQuestProperty);
                break;
        }

        EditorGUI.indentLevel--;
    }

    private void DrawButtonQuestGrid(Rect position, SerializedProperty buttonQuestProperty)
    {    
        float startX = position.x;
        float startY = position.y + EditorGUIUtility.singleLineHeight;
        float width = position.width / GridSize;
        float height = EditorGUIUtility.singleLineHeight;

        for (int i = 0; i < buttonQuestProperty.arraySize; i++)
        {
            int row = i / GridSize;
            int column = i % GridSize;

            Rect rect = new Rect(startX + column * width, startY + row * height, width, height);
            SerializedProperty elementProperty = buttonQuestProperty.GetArrayElementAtIndex(i);
            elementProperty.boolValue = EditorGUI.Toggle(rect, GUIContent.none, elementProperty.boolValue);
        }
    }
}