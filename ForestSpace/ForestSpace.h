#ifndef FORESTSPACE_H_INCLUDED
#define FORESTSPACE_H_INCLUDED

#include <string>

namespace ForestSpace
{
	
	enum GameStatus{
		ONGOING,
		LOST,
		WON
	};
	
	enum Action{
		NORTH,
		SOUTH,
		EAST,
		WEST,
		NORTHEAST,
		SOUTHEAST,
		NORTHWEST,
		SOUTHWEST,
		RELEASE
	};
	
	enum Feature{
		FIRE,
		UNBURNT,
		BURNT,
		WATER
	};
	
	constexpr char ENTETIES[6] = {'*','.', '#','W'};
	
	using Array1d = Feature*;
	using Array2d = Array1d*;
	
	struct Player{
		int intRow;
		int intCol;
	};
	
	struct gameWorld{
		Array2d arrForest;
		int intRow;
		int intCol;
		int Fire;
		int Water;
		int Tank;
		Player player;
	};
	
	gameWorld initGame( int Fire, int Water);
	void Movement(gameWorld& recWorld, Action eDir);
	void Display(gameWorld recWorld);
	void destroyWorld(gameWorld& recWorld);
	int convToInt(std::string strArg);
}

#endif 