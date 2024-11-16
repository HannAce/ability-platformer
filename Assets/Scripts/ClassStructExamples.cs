using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides examples of classes and structs as referenced variables
/// </summary>
public class ClassStructExamples : MonoBehaviour
{
    [Serializable]
    public class ClassExample
    {
        public string Name = "Hannah";
        public int Value = 7;
        public bool ExampleBool = true;

        public int GetDoubleValue()
        {
            return Value * 2;
        }
    }
    
    [Serializable]
    public struct StructExample
    {
        public string Name;
        public int Value;
        public bool ExampleBool;

        public int GetDoubleValue()
        {
            return Value * 2;
        }
    }

    public ClassExample ExampleVariable;
    public ClassExample ExampleVariable2;
    public StructExample Struct;
    
    private void Update()
    {
        Debug.Log("---");
        ExampleMethod(ExampleVariable);
        ExampleMethod(ExampleVariable2);
        ExampleMethod(Struct);
    }

    private void ExampleMethod(ClassExample example)
    {
        //Debug.Log(example.Name + " " + example.GetDoubleValue() + " " + example.ExampleBool);
        //Debug.Log("Name: {0}, Double Value: {1}, Bool: {2}", example.Name, example.GetDoubleValue(), example.ExampleBool);
        Debug.Log($"Name: {example.Name}, Double Value: {example.GetDoubleValue()}, Bool: {example.ExampleBool}");
    }

    /// <summary>
    /// This is an overload of ExampleMethod, but passing a struct instead of a class
    /// </summary>
    private void ExampleMethod(StructExample example)
    {
        Debug.Log($"Name: {example.Name}, Double Value: {example.GetDoubleValue()}");
    }
}
