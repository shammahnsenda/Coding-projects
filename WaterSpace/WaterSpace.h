#ifndef LIBCRISIS_H_INCLUDED
#define LIBCRISIS_H_INCLUDED

#include <string>

namespace WaterSpace
{
	enum GameState{
		ONGOING,
		WON,
		LOST
	};
	
	enum eFeatures{
		SPACE,
		WATER,
		PLAYER,
		VALVE,
		OBSTACLE
	};
	
	enum Direction{
		UP,
		DOWN,
		LEFT,
		RIGHT
	};
	
	using Array1d = eFeatures*;
	using Array2d = Array1d*;
	
	constexpr char ENTETIES[5] = {' ', '*', '@', '^', '#'};
	
	struct Player{
		int intCol;
		int intRow;
	};
	
	struct gameWorld{
		Array2d arrUpper;
		Array2d arrLower;
		int intRow;
		int intCol;
		int Obstacles;
		int Valves;
		Player player;
	};
	
	gameWorld initGame(int intRow, int intCol, int Obstacles, int Valves);
	void PlayerMove(gameWorld& recWorld, Direction eDir);
	void DisplayWorld(gameWorld recWorld, Array2d Arr);
	GameState Status(gameWorld recWorld);
	void deallocMem(gameWorld recWorld);
	int convToInt(std::string strArg);
	
	
	
}

#endif // LIBCRISIS_H_INCLUDED
