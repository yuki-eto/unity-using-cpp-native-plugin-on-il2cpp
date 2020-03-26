# unity-using-cpp-native-plugin-on-il2cpp

## how to debug on UnityEditor
need to build dynamic library(.dylib or .dll) for executable your platform.

please build [cpp-cmake-gtest-boilerplate](https://github.com/yuki-eto/cpp-cmake-gtest-boilerplate) before debug.
(using Docker and Docker Compose)

```
$ git submodule update --init
$ cd calc_lib

$ docker-compose run --rm ./build_osx.sh
or
$ docker-compose run --rm ./build_windows.sh

$ cp build-osx/src/libcalculator.dylib ../Assets/Plugins/
or
$ cp build-windows/src/libcalculator.dll ../Assets/Plugins/
```
