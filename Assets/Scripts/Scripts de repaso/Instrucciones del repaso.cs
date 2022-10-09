// REPASO


// para este repaso queremos revisar los temas de:
// SimpleMovement
//TriggerEnter
//Spawn De Enemigos

//para esto haremos un "Balloon poper", esto nos ayudará:
// simple movement = dandole movimiento a nuestro jugador
// Spawn de Enemigos = Spawnea Los ballons
// TriggerEnter = hace que los ballons exploten cuando los toquemos

//Requisitos:
//Agregar un Cubo que sea nuestro player 
//Agregar una esfera que sea nuestro ballon (Ballon)
//Agregar un EMptyObject que sea nuestro Spawner (Spawner)
//Agregar un segundo emptyObject que guardará nuestras copias de los ballons (Ballons)
//Crear el Tag de "Player", seleccionamos nuestro cubo y en el inspector a la derecha arriba donde dice tag le damos click y add tag, cuando lo creemos debes asegurarte que lo tiene puesto.
//
//los pasos son:
// 1.- crear el Script de movement y añadirselo al cubo
// 2.- crear el script de Spawner y añadirlo al EmptyObject
// 3.- crear el Script de BallonDespawn y añadirlo al ballon(esfera)
// 4.-hacer un prefab del ballon (solo arrastra el objeto a la carpeta de prefab y se hace solo)
// 5.- has click en el spawner y busca en el inspector el script de spawner, arrastra el prefad de ballon a "Object To Be Spawned", coloca el numero de items y en "Parent" pon el baul de clones (Ballons)
