cmake_minimum_required(VERSION 3.18)

project(MAIN)

set(VCPKG_INSTALLED_DIR "D:/SLAM/vcpkg/installed")
# set(OpenCV_DIR "${VCPKG_INSTALLED_DIR}/x64-windows/share/opencv3")
# find_package(OpenCV REQUIRED)
# include_directories(${OpenCV_INCLUDE_DIRS})

set(Eigen3_DIR "${VCPKG_INSTALLED_DIR}/x64-windows/share/eigen3")
find_package(Eigen3 CONFIG REQUIRED)

add_executable(main src/main.cc)

target_link_libraries(main Eigen3::Eigen)
# target_link_libraries(main ${OpenCV_LIBS})