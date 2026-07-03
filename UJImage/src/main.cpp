#include <cstdlib>
#include <iostream>
#include <string>
#include <fstream>


using namespace std;

import LibUtility;
import UJImage;

void loadImage(UJImage& image, string File);

void exportImage(const UJImage& image, string sPath, ExportMode Mode);


int main()
{
	
	UJImage image;
	string sFile = "../output/image_ng.ppm";
	string sPath = "../output";
	
	loadImage(image, sFile);
	exportImage(image, sPath, PPM);
	

    return SUCCESS;
}


void loadImage(UJImage& image, string File){
	
	ifstream FileExist(File);
	
	if (!FileExist){
		cerr << "File does not exist/ cannot be opened";
		exit(ERROR_FILE_OPEN);
	}
	
	string sFormat ;
	int iHeight, iWidth, iMaxValue;
	
	FileExist >> sFormat
              >> iHeight >> iWidth >> iMaxValue;
			  
	if (sFormat != "P3") {
    cerr << "Not a valid PPM file!\n";
    exit(ERROR_INVALID_FORMAT);
}		  
			  
	image =	UJImage(iHeight,iWidth); 
	
	UJPixel recPixel;
	
	for(int r = 0; r < image.getHeight(); r++){
		for(int c = 0; c < image.getWidth(); c++){
			
		    FileExist >> recPixel.intRed 
			          >> recPixel.intGreen
					  >> recPixel.intBlue;

             if(recPixel.intRed < 0 || recPixel.intRed > iMaxValue ||
			   recPixel.intGreen < 0 || recPixel.intGreen > iMaxValue ||
			   recPixel.intBlue < 0 || recPixel.intBlue > iMaxValue)
				{
					cerr << "Pixel value out of range\n";
					exit(ERROR_PIXEL_VALUE);
				}             
			 
			image.setPixel(r , c, recPixel);
             	
		}
		
	}
	FileExist.close();
}


bool isWhite(UJPixel recPixel)
{
    return recPixel.intRed == 255 && recPixel.intGreen == 255 && recPixel.intBlue == 255;
}

int average(UJPixel recPixel)
{
    return (recPixel.intRed + recPixel.intGreen + recPixel.intBlue) / 3;
}


void exportImage(const UJImage& image, string sPath, ExportMode Mode){
	switch(Mode)
	{
		case PPM:{
			string sFile = sPath + "/" + "image.ppm";
		   ofstream makeFile(sFile);
		   
		   if (!makeFile) {
				cerr << "Failed to create PPM file!" << endl;
				exit(ERROR_FILE_MAKE);
            }
			
			
		    makeFile << "P3" << "\n"
          << image.getWidth() << ' ' << image.getHeight() << "\n"
          << 255 << "\n";
		  
			for(int r = 0; r < image.getHeight(); r++){
				for(int c = 0; c < image.getWidth(); c++){
					UJPixel recPixel = image.getPixel( r, c);
					
					makeFile << recPixel.intRed <<" "
							 << recPixel.intGreen<<" "
							 << recPixel.intBlue<<" ";				  	  
				}
			  makeFile << "\n"; 
		    }
			makeFile.close();
			break;
		}
				
		case PBM:{
			string sFile = sPath + "/" + "image.pbm";
		   ofstream makeFile(sFile);
		    if (!makeFile) {
				cerr << "Failed to create PBM file!" << endl;
				exit(ERROR_FILE_MAKE);
            }
		
		   makeFile << "P1" << "\n"
            << image.getWidth() << ' ' << image.getHeight() << "\n";
			
			for(int r = 0; r < image.getHeight(); r++)
			{
				for(int c = 0; c < image.getWidth(); c++)
				{
					int intBitValue = isWhite(image.getPixel(r, c)) ? 0 : 1;
					makeFile << intBitValue << ' ';
				}
				makeFile << "\n";
			}
			makeFile.close();
		break;
		}
		
		case PGM:{
			string sFile = sPath + "/" + "image.pgm";
		   ofstream makeFile(sFile);
		    if (!makeFile) {
				cerr << "Failed to create PGM file!" << endl;
				exit(ERROR_FILE_MAKE);
            }
		
		   makeFile << "P2" << "\n"
            << image.getWidth() << ' ' << image.getHeight() << "\n"
			<< 255 << "\n";
			
			for(int r = 0; r < image.getHeight(); r++)
			{
				for(int c = 0; c < image.getWidth(); c++)
				{
					int intIntensity = average(image.getPixel(r, c));
                    makeFile << intIntensity << ' ';
				}
				makeFile << "\n";
			}
			
			makeFile.close();
		break;
		}
	}
	
	
}