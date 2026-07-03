module;

#include <cstdlib>
#include <iostream>
#include <sstream>
#include <string>

export module LibUtility;

export struct UJPixel
{
    int intRed;
    int intGreen;
    int intBlue;
};

export using Row = UJPixel*;
export using Grid = Row*;

export enum ExitCode
{
    SUCCESS,
    ERROR_RANGE,
    ERROR_ARGS,
    ERROR_CONV,
	ERROR_FILE_OPEN,
	ERROR_FILE_MAKE,
	ERROR_INVALID_FORMAT,
	ERROR_PIXEL_VALUE
};

export enum FlagType
{
    AUSTRIA,
    JAPAN,
    NIGERIA
};

export enum ExportMode
{
	PPM,
	PGM,
	PBM	
};

export FlagType convToFlagType(std::string strArg)
{
    std::stringstream ssConv{strArg};
    int intTemp = 0;
    ssConv >> intTemp;

    if (ssConv.fail() || intTemp < 0 || intTemp > 2)
    {
        std::cerr << "ERROR! Could not convert command line argument to a flag type. Terminating."
                  << std::endl;
        exit(ERROR_CONV);
    }

    return static_cast<FlagType>(intTemp);
}


