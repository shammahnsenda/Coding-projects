module;

#include <cassert>
#include <iostream>
#include <sstream>
#include <string>

export module UJImage;

import LibUtility;

// Same as -> typedef UJPixel* Row;


/*
 * Class declaration.
 */
export class UJImage
{
public:
    // Default Constructor.
    UJImage();

    // Constructor with parameters.
    UJImage(int intRows, int intCols);

    // Copy constructor.
    UJImage(const UJImage& objOriginal);

    // Destructor.
    ~UJImage();
    
	
    // Accessors functions (getters).
    int getHeight() const; // Returns the height (_rows) of the image.
    int getWidth() const;  // Returns the width (_cols) of the image.
    UJPixel getPixel(int intRow, int intCol) const; // Accessor for a single pixel.

    // Mutator function (setter).
    void setPixel(int intRow, int intCol, UJPixel recPixel); // Modify a single pixel.

    /*
     * Class constants
     */
    static constexpr int DEFAULT_ROWS = 2;
    static constexpr int DEFAULT_COLS = 2;
    static constexpr UJPixel DEFAULT_PIXEL = {255, 255, 255}; // Initialiser list.

private:
    // Helper functions.
    void alloc(int intRows, int intCols);
    void clone(const UJImage& objOriginal);
    void dealloc();
    void enforceRange(int intValue, int intMin, int intMax) const;

    // State variables.
    Grid _image;
    int _rows;
    int _cols;
};

/*
 * Class definition.
 */
UJImage::UJImage() : UJImage(DEFAULT_ROWS, DEFAULT_COLS)
{
}

UJImage::UJImage(int intRows, int intCols)
{
    alloc(intRows, intCols);
}

UJImage::UJImage(const UJImage& objOriginal)
    : UJImage(objOriginal._rows, objOriginal._cols)
{
    clone(objOriginal);
}

UJImage::~UJImage()
{
    dealloc();
}



void UJImage::alloc(int intRows, int intCols)
{
    _rows = intRows;
    _cols = intCols;

    _image = new Row[_rows];
    for (int r = 0; r < _rows; r++)
    {
        _image[r] = new UJPixel[_cols];
        for (int c = 0; c < _cols; c++)
        {
            _image[r][c] = DEFAULT_PIXEL;
        }
    }
}

void UJImage::clone(const UJImage& objOriginal)
{
    assert(_rows == objOriginal._rows);
    assert(_cols == objOriginal._cols);

    for (int r = 0; r < _rows; r++)
    {
        for (int c = 0; c < _cols; c++)
        {
            // Deep copy of the 2D array.
            _image[r][c] = objOriginal._image[r][c];
        }
    }
}

void UJImage::dealloc()
{
    for (int r = 0; r < _rows; r++)
    {
        delete[] _image[r];
    }
    delete[] _image;
}

int UJImage::getHeight() const
{
    return _rows;
}

int UJImage::getWidth() const
{
    return _cols;
}

UJPixel UJImage::getPixel(int intRow, int intCol) const
{
    // Ensure valid access.
    enforceRange(intRow, 0, _rows - 1);
    enforceRange(intCol, 0, _cols - 1);
    return _image[intRow][intCol];
}

void UJImage::setPixel(int intRow, int intCol, UJPixel recPixel)
{
    // Ensure valid modification.
    enforceRange(intRow, 0, _rows - 1);
    enforceRange(intCol, 0, _cols - 1);
    enforceRange(recPixel.intRed, 0, 255);
    enforceRange(recPixel.intGreen, 0, 255);
    enforceRange(recPixel.intBlue, 0, 255);

    _image[intRow][intCol] = recPixel;
}

void UJImage::enforceRange(int intValue, int intMin, int intMax) const
{
    if (intValue < intMin || intValue > intMax)
    {
        std::cerr << "ERROR! " << intValue
                  << " must be within [" << intMin << ", "
                  << intMax << "]. Terminating."
                  << std::endl;
        exit(ERROR_RANGE);
    }
}
