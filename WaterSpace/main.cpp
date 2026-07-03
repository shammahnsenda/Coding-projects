#include "WaterSpace.h"

#include <iostream>
#include <ctime>

using namespace std;
using namespace WaterSpace;

int main(int argc, char** argv){
	
	srand(time(nullptr));
	
	if(argc != 5){
		cout << "Invalid arguments";
		exit(-1);
	}
	
	int intRows = convToInt(argv[1]);
    int intCols = convToInt(argv[2]);
    int intObstacles = convToInt(argv[3]);
    int intValves = convToInt(argv[4]);
	
	if(intRows <= 0 ||
       intCols <= 0 ||
       intObstacles < 0 ||
       intValves < 0)
    {
        cerr << "Something wrong with the arguments!" << endl;
        exit(-1);
    }
	
	gameWorld recWorld = initGame(intRows, intCols, intObstacles, intValves);
		char Move;
		GameState StatusGame = ONGOING;
	do{
		
		DisplayWorld(recWorld, recWorld.arrLower);
		
		switch(cin >> Move; toupper(Move)){
			case 'W':
			{
				PlayerMove(recWorld, UP);
				break;
			}
			case 'S':
			{
				PlayerMove(recWorld, DOWN);
				break;
			}
			case 'D':
			{
				PlayerMove(recWorld, RIGHT);
				break;
			}
			case 'A':
			{
				PlayerMove(recWorld, LEFT);
				break;
			}
			case 'T':
			{
				DisplayWorld(recWorld, recWorld.arrUpper);
				 cout << "\n[VIEWING UPPER LAYER] Press any key + Enter to return to ground: ";
    
				char backInput;
				cin >> backInput;
				
				break;
			}
			case 'B':
			{
				break;
			}
		}
		StatusGame = Status(recWorld);
	}while(StatusGame == ONGOING);
		
	deallocMem(recWorld);

    if(StatusGame == LOST)
    {
        cout << "YOU LOSE!" << endl;
    }
    else if(StatusGame == WON)
    {
        cout << "YOU WIN!!!" << endl;
    }
    return 0;
}