#include "ForestSpace.h"

#include <cassert>
#include <iostream>
#include <sstream>

using namespace std;

namespace ForestSpace{
	
	Array2d allocMem(int intRow, int intCol){
		
		assert(intRow > 0 && intCol > 0);
		
		Array2d arr = new Array1d[intRow];
		for(int i = 0; i < intRow; i++){
			arr[i] = new Feature[intCol];
			for(int k = 0; k < intCol; k++){
				arr[i][k] = UNBURNT;
			}
		}
		
		return arr;
	}
	
	int randomNum(int Lower, int Upper){
		int Range = Upper - Lower + 1;
		return (rand() % Range) + Lower;
	}
	
	void PlaceInWorld(gameWorld& recWorld){
		int count = 0;
		int num1 = 0;
		int num2 = 0;
		
		//placing fire
		while(count != recWorld.Fire){
			num1 = randomNum(0, recWorld.intRow-1);
			num2 = randomNum(0, recWorld.intCol-1);
			
			if(recWorld.arrForest[num1][num2] == UNBURNT){
				recWorld.arrForest[num1][num2] = FIRE;
				count++;
			}
		}
		
		//placing Water
		count = 0;
		while(count != recWorld.Water){
			num1 = randomNum(0, recWorld.intRow-1);
			num2 = randomNum(0, recWorld.intCol-1);
			
			if(recWorld.arrForest[num1][num2] == UNBURNT){
				recWorld.arrForest[num1][num2] = WATER;
				count++;
			}
		}
	
	}
	
	gameWorld initGame( int Fire, int Water){
		
		gameWorld recWorld;
		
		recWorld.intCol = randomNum(5,20);;
		recWorld.intRow = randomNum(5,20);;
		recWorld.Fire = Fire;
		recWorld.Water = Water;
		recWorld.Tank = 5;
		recWorld.arrForest = allocMem(recWorld.intRow, recWorld.intCol);
		recWorld.player.intRow = randomNum(0,recWorld.intRow-1);
		recWorld.player.intCol= randomNum(0,recWorld.intCol-1);
		
		PlaceInWorld(recWorld);
		
		return recWorld;

	}
	
	bool inRange(gameWorld recWorld, int intRow, int intCol){
		return(intRow >= 0 && intRow < recWorld.intRow && intCol >= 0 && intCol < recWorld.intCol);
	}
	
	void Movement(gameWorld& recWorld, Action eDir){
		int dirRow = recWorld.player.intRow;
		int dirCol = recWorld.player.intCol;
		
		switch(eDir){
			case NORTH:
			{
				dirRow--;
				break;
			}
			case SOUTH:
			{
				dirRow++;
				break;
			}
			case EAST:
			{
				dirCol++;
				break;
			}
			case WEST:
			{
				dirCol--;
				break;
			}
			case NORTHEAST:
			{
				dirRow--;
				dirCol++;
				break;
			}
			case SOUTHEAST:
			{
				dirRow++;
				dirCol++;
				break;
			}
			case NORTHWEST:
			{
				dirRow--;
				dirCol--;
				break;
			}
			case SOUTHWEST:
			{
				dirRow++;
				dirCol--;
				break;
			}
		}

		if(inRange(recWorld, dirRow, dirCol))
		{
			recWorld.player.intRow = dirRow;
			recWorld.player.intCol = dirCol;
			
			if(recWorld.arrForest[dirRow][dirCol] == WATER){
				recWorld.Tank += 3;
			}
		}
	
		if(eDir == RELEASE){
			recWorld.Tank -= 1;
			
			for(int r = recWorld.player.intRow - 1 ; r <= recWorld.player.intRow + 1; r++){
				for(int c = recWorld.player.intCol - 1 ; c <= recWorld.player.intCol + 1; c++){
					if(inRange(recWorld, r,c)){
						if(recWorld.arrForest[r][c] == FIRE){
							recWorld.arrForest[r][c] = BURNT;
						}
					}
				}
			}
		}
	}
	
	void Display(gameWorld recWorld){
		system("cls");
		for(int r = 0 ; r < recWorld.intRow; r++){
			for(int c = 0 ; c < recWorld.intCol; c++){
				if(recWorld.player.intRow == r && recWorld.player.intCol == c){
					cout << "@" << " ";
				}else{
					cout<< ENTETIES[recWorld.arrForest[r][c]] << " ";
				}
			}
			cout << endl;
		}
		
		
	}
	
	void destroyWorld(gameWorld& recWorld){
		
		for(int i = 0; i < recWorld.intRow; i++){
			delete [] recWorld.arrForest[i];
		}
		recWorld.arrForest =  nullptr;
	}
	
	int convToInt(string strArg)
    {
        stringstream ssConv(strArg);
        int intReturn = 0;
        ssConv >> intReturn;
        if(ssConv.fail())
        {
            cerr << strArg << " is not an integer." << endl;
            exit(-1);
        }
        return intReturn;
    }
	
	
}
	
	
	
