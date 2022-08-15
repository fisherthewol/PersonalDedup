namespace PersonalDedupeTest;

public class ImageDedupUnitTest
{
    /// <summary>
    /// Tests that two known-different images get a likelihood of 1 for same extension.
    /// </summary>
    /// <param name="image1">Filename of first image to test.</param>
    /// <param name="image2">Filename of second image to test.</param>
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_0064.JPG")]
    public void KnownDifferentImagesAreExtensionEqual(string image1, string image2)
    {
        FileInfo fiImage1 = new FileInfo(image1);
        FileInfo fiImage2 = new FileInfo(image2);
        Assert.Equal(1, ImageDedup.ImagesLikelyDuplicate(fiImage1, fiImage2));
    }
    
    /// <summary>
    /// Tests that two known-same images get a likelihood of 2:
    /// - Same extension
    /// - Same length
    /// </summary>
    /// <param name="image1">Filename of first image to test.</param>
    /// <param name="image2">Filename of second image to test.</param>
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_DUP.JPG")]
    public void KnownDuplicateImagesAreLengthEqual(string image1, string image2)
    {
        FileInfo fiImage1 = new FileInfo(image1);
        FileInfo fiImage2 = new FileInfo(image2);
        Assert.Equal(2, ImageDedup.ImagesLikelyDuplicate(fiImage1, fiImage2));
    }
    
    /// <summary>
    /// Tests that two known-different images created at the same time get a likelihood of 2:
    /// - Same extension
    /// - Same creation time.
    /// </summary>
    /// <param name="image1">Filename of first image to test.</param>
    /// <param name="image2">Filename of second image to test.</param>
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_TIM.JPG")]
    public void TestCreationTimeComparison(string image1, string image2)
    {
        FileInfo fiImage1 = new FileInfo(image1);
        FileInfo fiImage2 = new FileInfo(image2) { CreationTimeUtc = fiImage1.CreationTimeUtc };
        Assert.Equal(2, ImageDedup.ImagesLikelyDuplicate(fiImage1, fiImage2));
    }
    
    /// <summary>
    /// Tests that, when passed a non-existent file, ImagesLikelyDuplicate throws an ArgumentException.
    /// </summary>
    /// <param name="validImage">Filename of a valid image to test other parameter with.</param>
    [Theory]
    [InlineData("HNI_0063.JPG")]
    public void NonExistentImageThrowsArgumentError(string validImage)
    {
        FileInfo fiValid = new FileInfo(validImage);
        FileInfo fiNonExist = new FileInfo("BadFileNameDoesntExist.jpg");
        // Test with parameter image1 as bad:
        Assert.Throws<ArgumentException>(() => ImageDedup.ImagesLikelyDuplicate(fiNonExist, fiValid));
        // Test with parameter image2 as bad:
        Assert.Throws<ArgumentException>(() => ImageDedup.ImagesLikelyDuplicate(fiValid, fiNonExist));
        // Test with both parameters as bad:
        Assert.Throws<ArgumentException>(() => ImageDedup.ImagesLikelyDuplicate(fiNonExist, fiNonExist));
    }
    
    /// <summary>
    /// Tests that, when passed an existing file, ImagesLikelyDuplicate does not throw an ArgumentException.
    /// https://peterdaugaardrasmussen.com/2019/10/27/xunit-how-to-check-if-a-call-does-not-throw-an-exception/
    /// </summary>
    /// <param name="validImage">Filename of a valid image to test with.</param>
    [Theory]
    [InlineData("HNI_0063.JPG")]
    public void ExistingImageThrowsArgumentError(string validImage)
    {
        FileInfo fiValid = new FileInfo(validImage);
        var exception = Record.Exception(() => ImageDedup.ImagesLikelyDuplicate(fiValid, fiValid));
        Assert.Null(exception);
    }
    
    /// <summary>
    /// Return data for testing with lists of filenames.
    /// </summary>
    /// <returns>IEnumerable for [MemberData].</returns>
    public static IEnumerable<object[]> FileData(){
        yield return new object[] { 2, new List<string>{ "HNI_0063.JPG", "HNI_0064.JPG", "HNI_DUP.JPG", "HNI_TIM.JPG" } };
    }

    /// <summary>
    /// Tests that, when passed
    /// </summary>
    /// <param name="duplicateLevel">Similarity at which image should be considered duplicate.</param>
    /// <param name="filenames">List of filesnames</param>
    [Theory]
    [MemberData(nameof(FileData))]
    public void KnownSetReturnsExpectedDuplicateSetFromList(int duplicateLevel, List<string> filenames)
    {
        IFileDedup imageDedup = new ImageDedup(duplicateLevel);
        throw new NotImplementedException();
    }
}