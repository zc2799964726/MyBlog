#include<Eigen/Eigen>
#include<iostream>
using namespace std;
using namespace Eigen;
int main(){
    Matrix3d rotation_matrix3d = Eigen::Matrix3d::Identity();
    cout << rotation_matrix3d;

    return 0;
}