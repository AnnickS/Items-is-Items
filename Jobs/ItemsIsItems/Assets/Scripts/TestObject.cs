using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestObject", menuName = "Test/TestObject", order = 1)]
class TestObject :  ScriptableObject {

    public String Name;
    public String Description;
}