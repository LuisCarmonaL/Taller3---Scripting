using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Factory
{
    public abstract class Objeto
    {
        public abstract string Name { get; }
        public abstract void Instanciar();
    }

    public class Cubo : Objeto
    {
        public override string Name => "cubo";
        public override void Instanciar()
        {
            GameObject.FindObjectOfType<FactoryMaster>().MaterializarObjeto(0);
        }
    }

    public class Esfera : Objeto
    {
        public override string Name => "esfera";
        public override void Instanciar()
        {
            GameObject.FindObjectOfType<FactoryMaster>().MaterializarObjeto(1);
        }
    }

    public class Cilindro : Objeto
    {
        public override string Name => "cilindro";
        public override void Instanciar()
        {
            GameObject.FindObjectOfType<FactoryMaster>().MaterializarObjeto(2);
        }
    }

    public static class ObjectFactory
    {
        private static Dictionary<string, Type> objectsByNames;
        private static bool IsInitialized => objectsByNames != null;


        public static void InitializeFactory()
        {
            if (IsInitialized)
                return;

            var objectTypes = Assembly.GetAssembly(typeof(Objeto)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Objeto)));

            objectsByNames = new Dictionary<string, Type>();

            foreach(var type in objectTypes)
            {
                var tempEffect = Activator.CreateInstance(type) as Objeto;
                objectsByNames.Add(tempEffect.Name, type);
            }
        }

        public static Objeto GetObject(string objectType)
        {
            InitializeFactory();

            if(objectsByNames.ContainsKey(objectType))
            {
                Type type = objectsByNames[objectType];
                var objeto = Activator.CreateInstance(type) as Objeto;
                return objeto;
            }

            return null;
        }

        internal static IEnumerable<string> GetObjectNames()
        {
            Debug.Log("Test");
            InitializeFactory();
            return objectsByNames.Keys;
        }
    }
}
