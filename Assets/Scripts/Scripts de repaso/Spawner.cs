using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] int numberOfItems;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
           Vector3 SpawnRandom = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f),
                Random.Range(0f, 0f));
            Instantiate(objectToBeSpawned, SpawnRandom, Quaternion.identity, parent);
            //PrefabUtility.InstantiatePrefab(objectToBeSpawned, position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


// OJO codigo y explicación en: https://www.youtube.com/watch?v=ycPhF_UyFo4 // es distinto al del profe pero se me hace más facil de entender
// RECOMENDACIÓN ver primero el video VELO PLS, este es el codigo terminado, ahi te va diciendo paso por paso y los posibles cambios que pudieras hacer, luego lee las anotaciones si te quedaron dudas
//  
// En este Spawner estaremos Spawneando varios objetos a la vez y en posiciones random
// Agregar ("using UnityEditor;") hasta mero arriba para que funcionen ciertas lineas
// crear un SerializeField privado para poder seleccionar en unity el objeto que querramos qeu spawné ([SerializeField] private GameObject objectToBeSpawned;)
// explicación: estás creando un tipo de almacenamiento o vaúl, donde en unity pondrás un objeto para que lo almacene y luego lo spawne/duplique
// * el nombre ObjectToBeSpawned es solo el nombre del almacenamiento de la variable, lo puedes cambiar a lo que gustes
// abrimos otro serializeField pero ahora para almacenar numeros (int), estamos creando un baúl para indicar el numero de numeros de ballons que queremos que aparezcan
// el ultimo serialized fiel es para colocar nuestro vaúl que guardará nuestras copias 

// dentro del void Start, escribe un "for" si presionas la tecla "Tab" 2 veces justo despues de escribirlo te aparecerá todo lo de ((int i = 0; i < numberOfItems; i++)) solo asegurate que el nombre que contenga si sea "numberOfItems".
// *Los vector 3 sirven para triangular posiciones x,y,z*
// creamos un Vector 3 y le ponemos un nombre para identificarlo, decimos que este vector 3 es igual a un rango random entre 2 opciones, Vector3 SpawnRandom = (new Vector3(Random.Range(-5f, 5f))
// Explicación :
// Random.Range(-5f, 5f) = los numeros -5f, 5f son tus limites "escoge un numero random entre -5 y 5", las letras "f" simbolizan unidades
// los numeros dentro del random.range pueden ser modificados al gusto 
// se ponene 3 veces un (Random.Range(-5f, 5f) porqeu es uno por cada eje (uno por x, uno por y, uno por z), si te fijas el ultimo qeu es el de z lo deje en ceros porque quiero qeu el juego sea en 2d, si le pones cosas en Z le dará profundidad a los globos y no podrá alcanzarlos
//
// ahora le pedimos que nos cree instancias de los ballons, que les ponga posición random y que los guarde en el almacen de copias(Instantiate(objectToBeSpawned, SpawnRandom, Quaternion.identity, parent);)
// Explicación:
// El Instance nos dice que se crearán instancias de un objeto(copias)
// Primero se declara el objeto a copiar = (ObjectToBeSpawned) "el objecttobespawned es lo que nos guarda nuestro objeto ballon, para que lo saque de ahi y haga copias"
// luego le dices que la posición de spawn sea la que creaste para que fuera random (SpawnRandom), este es el nombre que le diste a tu vector3 para hacer las cosas random 
// el (Quaternion.identity) nos ayuda a que el objeto no rote cuando spawne clones, esto no se nota en nuestro juego porque son esferas pero puede afectar en otras ocaciones
// (parent) le dice que lo almacene en el parent, es decir en el vaúl de copias

// RECUERDA este codigo es distinto al del profe aqunqeu funciona y te ayuda a dar una idea de como funciona el spawn, aunque recomiendo que trates de entender el del prof
