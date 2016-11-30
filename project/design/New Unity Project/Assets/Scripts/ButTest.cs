using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButTest : MonoBehaviour {



    void Start()
    {
        A a = new A();

        B b = new B();

        MyTest(a);
        MyTest(b);

    }


    public class A
    {
        public int num = 10;
    }


    public class B
    {
        public int num = 20;
    }



    void MyTest<T>(T t)
    {
        //在这里怎么取到 num 的值 
        Debug.Log(t.GetType()) ;


        if (t is A)
        {

        }

    }



}
