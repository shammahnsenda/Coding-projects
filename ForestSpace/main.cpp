#include "ForestSpace.h"
#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;
using namespace ForestSpace;

int main(int argc, char** argv){
	
	if(argc != 3){
		cout << "Wrong arguments";
		exit(-1);
	}
	
	int Fire = convToInt(argv[1]);
	int Water = convToInt(argv[2]);
	
	if(Fire < 0 || Water < 0){
		cout << "invalid arguments";
		 exit(-1);
	}
	
	gameWorld recWorld;
	recWorld = initGame(Fire,Water);
	
	bool blnContinue = true;
    do
    {
        Display(recWorld);
        char chOption = '\0';
        switch(cin >> chOption; toupper(chOption))
        {
        case 'W':
            {
                Movement(recWorld, NORTH);
                break;
            }
        case 'S':
            {
                Movement(recWorld, SOUTH);
                break;
            }
        case 'A':
            {
                Movement(recWorld, WEST);
                break;
            }
        case 'D':
            {
                Movement(recWorld, EAST);
                break;
            }
		case 'Q':
            {
                Movement(recWorld, NORTHWEST);
                break;
			}
		case 'E':
            {
                Movement(recWorld, NORTHEAST);
                break;
			}
		case 'C':
            {
                Movement(recWorld, SOUTHEAST);
                break;
			}
		case 'Z':
            {
                Movement(recWorld, SOUTHWEST);
                break;
			}
        case 'F':
            {
                Movement(recWorld, RELEASE);
                break;
            }
        case 'G':
            {
                cout << "Bye." << endl;
                blnContinue = false;
            }
        }
    }while(blnContinue);
	destroyWorld(recWorld);
	
	
	return 0;
	
	
}