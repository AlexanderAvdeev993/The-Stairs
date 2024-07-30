using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(QuestAnswer))]
public class QuestAnswerDrawer : PropertyDrawer
{
    private const int GridSize = 4;
    private const float Spacing = 30f; // Add spacing between elements

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var questType = (QuestType)property.FindPropertyRelative("QuestType").enumValueIndex;

        float baseHeight = EditorGUIUtility.singleLineHeight;
        float additionalHeight = 0;

        switch (questType)
        {
            case QuestType.ButtonQuest:
                additionalHeight = EditorGUIUtility.singleLineHeight * GridSize + EditorGUIUtility.singleLineHeight + Spacing; // 4 rows * single line height + SpriteHint field
                break;
            case QuestType.MathQuest:
                additionalHeight = EditorGUIUtility.singleLineHeight;
                break;
        }

        // Add extra spacing for each element
        return baseHeight + additionalHeight + Spacing;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var questTypeProperty = property.FindPropertyRelative("QuestType");
        var buttonQuestProperty = property.FindPropertyRelative("ButtonQuestAnswer");
        var intQuestProperty = property.FindPropertyRelative("IntQuest");
        var spriteHintProperty = property.FindPropertyRelative("SpriteHint");

        // Get the index of the current property
        int index = GetIndexFromPropertyPath(property.propertyPath);

        // Draw the index label
        Rect indexLabelRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(indexLabelRect, $"Quest Answer {index + 1}");

        // Move the position down for the next property
        position.y += EditorGUIUtility.singleLineHeight;

        EditorGUI.PropertyField(
            new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
            questTypeProperty);

        EditorGUI.indentLevel++;

        var questType = (QuestType)questTypeProperty.enumValueIndex;

        switch (questType)
        {
            case QuestType.ButtonQuest:
                DrawButtonQuestGrid(position, buttonQuestProperty);
                position.y += EditorGUIUtility.singleLineHeight * GridSize + 40;
                EditorGUI.PropertyField(
                    new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                    spriteHintProperty);
                position.y += EditorGUIUtility.singleLineHeight + Spacing;
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
        float startX = position.x ;
        float startY = position.y + 30;
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

    private int GetIndexFromPropertyPath(string propertyPath)
    {
        string[] splitPath = propertyPath.Split('[', ']');
        for (int i = 0; i < splitPath.Length; i++)
        {
            int result;
            if (int.TryParse(splitPath[i], out result))
            {
                return result;
            }
        }
        return -1;
    }
}