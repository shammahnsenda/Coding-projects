#include "WaterSpace.h"

#include <cassert>
#include <sstream>
#include <iostream>
#include <cmath>

using namespace std;

namespace WaterSpace{
	
	Array2d allocMem(int Row, int Col){
		
		assert(Row > 0 && Col > 0);
		Array2d arr = new Array1d[Row];
		
		for(int r = 0; r < Row; r++){
			arr[r] = new eFeatures[Col];
			for(int c = 0; c < Col; c++){
			    arr[r][c] = SPACE;
		    }
		}
		
		return arr;
	}
	
	int RandomNum(int lower, int upper){
		int Range = upper - lower + 1;
		return (rand() % Range) + lower; 	
	}
	
	void PlaceInWorld(gameWorld& recWorld){
		
		//place player
		recWorld.player.intRow = RandomNum(0, recWorld.intRow-1);
		recWorld.player.intCol = RandomNum(0, recWorld.intCol-1);
		recWorld.arrLower[recWorld.player.intRow][recWorld.player.intCol] = PLAYER;
		
		//place obstacles
		int count = 0;
		while(count < recWorld.Obstacles){
			int ranRow = RandomNum(0, recWorld.intRow-1);
			int ranCol = RandomNum(0, recWorld.intCol-1);
			if(recWorld.arrLower[ranRow][ranCol] == SPACE){
				recWorld.arrLower[ranRow][ranCol] = OBSTACLE;
				count++;
			}	
		}
		
		//place Valves
	     count = 0;
		while(count < recWorld.Valves){
			int ranRow = RandomNum(0, recWorld.intRow-1);
			int ranCol = RandomNum(0, recWorld.intCol-1);
			if(recWorld.arrLower[ranRow][ranCol] == SPACE){
				recWorld.arrLower[ranRow][ranCol] =VALVE;
				count++;
			}	
		}
		
		//place Water
		for(int r = 0; r < recWorld.intRow; r++){
			for(int c = 0; c < recWorld.intCol; c++){
			    if(recWorld.arrLower[r][c] == VALVE){
					recWorld.arrUpper[r][c] = WATER;
				}
		    }
		}
		
	}
	
	gameWorld initGame(int intRow, int intCol, int Obstacles, int Valves){
		
		gameWorld recWorld;
		
		recWorld.intRow = intRow;
		recWorld.intCol = intCol;
		recWorld.Obstacles = Obstacles;
		recWorld.Valves = Valves;
		recWorld.arrUpper = allocMem(intRow, intCol);
		recWorld.arrLower = allocMem(intRow, intCol);
		
		PlaceInWorld(recWorld);
		
		return recWorld;
	}
	
	bool inRange(gameWorld recWorld, int row, int col){
		if(row < 0 || row >= recWorld.intRow || col < 0 || col >= recWorld.intCol )
			return false;
		return true;
	}
	
    Array2d cloneArr(gameWorld recWorld){
		Array2d arrCopy = allocMem(recWorld.intRow, recWorld.intCol);
		
		for(int r = 0; r < recWorld.intRow; r++){
			for(int c = 0; c < recWorld.intCol; c++){
			    arrCopy[r][c] = recWorld.arrUpper[r][c];
		    }
		}
		return arrCopy;
	}
	
	void UpdateWater(gameWorld& recWorld){
		Array2d arrNew = cloneArr(recWorld);
		
		for(int r = 0; r < recWorld.intRow; r++){
			for(int c = 0; c < recWorld.intCol; c++){
			    
				if(recWorld.arrUpper[r][c] == WATER){
					for(int i = r - 1; i <= r + 1; i++ ){
						for(int k = c - 1; k <= c + 1; k++ ){
							
							if(inRange(recWorld,i,k)){
								arrNew[i][k] = WATER;
							}
							
					    }
					}
				}
		    }
		}
		
		 for(int r = 0; r < recWorld.intRow; r++){
			for(int c = 0; c < recWorld.intCol; c++){
			    recWorld.arrUpper[r][c] = arrNew[r][c];
		    }
		}
	} 
	
	void PlayerMove(gameWorld& recWorld, Direction eDir){
		
		int dirRow = recWorld.player.intRow;
		int dirCol = recWorld.player.intCol;
		
		switch(eDir){
			case UP :
			{
				dirRow--;
				break;
			}
			case DOWN :
			{
				dirRow++;
				break;
			}
			case LEFT :
			{
				dirCol--;
				break;
			}
			case RIGHT :
			{
				dirCol++;
				break;
			}
		}
		
		if(inRange(recWorld, dirRow, dirCol)){
			if(recWorld.arrLower[dirRow][dirCol] != OBSTACLE)
			{
					
				recWorld.arrLower[dirRow][dirCol] = PLAYER;
				recWorld.arrLower[recWorld.player.intRow][recWorld.player.intCol] = SPACE;
				recWorld.player.intRow = dirRow;
				recWorld.player.intCol = dirCol;
				
				UpdateWater(recWorld);
			}
		}
	}
	
	void DisplayWorld(gameWorld recWorld, Array2d Arr){
		system("cls");
		
		for(int r = 0; r < recWorld.intRow; r++){
			for(int c = 0; c < recWorld.intCol; c++){
			    cout << ENTETIES[Arr[r][c]] << " ";
		    }
		 cout << endl;
		}
		cout<< endl;
		cout<< "W : Up" << endl;
		cout<< "S : Down" << endl;
		cout<< "D : Right" << endl;
		cout<< "A : Left" << endl;
		cout<< "T : See Ground" << endl;
		cout<< "B : Go Back" << endl;
		cout<< "Q: Quit" << endl;
	}
	
	
	GameState Status(gameWorld recWorld){
	
		bool check = false;
		bool valveCheck = false;
		
		for(int r = 0; r < recWorld.intRow; r++){
			for(int c = 0; c < recWorld.intCol; c++){
			    //Upper check
				if(recWorld.arrUpper[r][c] == SPACE){
					check = true;
				}
				
				//lower Check
				if(recWorld.arrLower[r][c] == VALVE){
					valveCheck = true;
				}
		    }
		}
		
		if(valveCheck == false && check == true ){
			return WON;
		}
		
		if(check == true){
			return ONGOING;
		}else{
			return LOST;
		}
		
	}
	
	void deallocMem(gameWorld recWorld){
		
		for(int r = 0; r < recWorld.intRow; r++){
			delete [] recWorld.arrLower[r];
			delete [] recWorld.arrUpper[r];
		}
		
		recWorld.arrUpper = nullptr;
		recWorld.arrLower = nullptr;	
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
	