﻿using elp87.TagReader;
using elp87.TagReader.id3v2;
using elp87.TagReader.id3v2.Frames;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace id3v2Tests.Frames
{
    [TestClass]
    public class Frames_UfidFrameTest
    {
        private const string _fileNameUFID = @"D:\TestAudio\UFID.mp3";
        private const string _expOwnerID = @"http://www.cddb.com/id3/taginfo1.html";
        private readonly byte[] _expValue = new byte[] 
        { 
            0x33, 0x43, 0x44, 0x33, 0x4E, 0x39, 0x33, 0x51, 0x32, 0x36, 0x39, 0x33, 0x36, 0x35, 0x39, 0x33, 
            0x32, 0x55, 0x32, 0x31, 0x38, 0x35, 0x43, 0x34, 0x43, 0x41, 0x31, 0x34, 0x44, 0x35, 0x43, 0x44, 
            0x32, 0x32, 0x39, 0x46, 0x38, 0x38, 0x37, 0x37, 0x32, 0x36, 0x42, 0x30, 0x31, 0x31, 0x36, 0x44, 
            0x38, 0x42, 0x38, 0x42, 0x42, 0x50, 0x32
        };
        private readonly byte[] _data = new byte[] 
        { 
            0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x77, 0x77, 0x77, 0x2E, 0x63, 0x64, 0x64, 0x62, 0x2E, 
            0x63, 0x6F, 0x6D, 0x2F, 0x69, 0x64, 0x33, 0x2F, 0x74, 0x61, 0x67, 0x69, 0x6E, 0x66, 0x6F, 0x31, 
            0x2E, 0x68, 0x74, 0x6D, 0x6C, 0x00, 0x33, 0x43, 0x44, 0x33, 0x4E, 0x39, 0x33, 0x51, 0x32, 0x36, 
            0x39, 0x33, 0x36, 0x35, 0x39, 0x33, 0x32, 0x55, 0x32, 0x31, 0x38, 0x35, 0x43, 0x34, 0x43, 0x41, 
            0x31, 0x34, 0x44, 0x35, 0x43, 0x44, 0x32, 0x32, 0x39, 0x46, 0x38, 0x38, 0x37, 0x37, 0x32, 0x36, 
            0x42, 0x30, 0x31, 0x31, 0x36, 0x44, 0x38, 0x42, 0x38, 0x42, 0x42, 0x50, 0x32
        };


        private FrameFlagSet ffs;

        public Frames_UfidFrameTest()
        {
            ffs = new FrameFlagSet(new byte[] { 0x00, 0x00 });
        }

        [TestMethod]
        public void TestReadDate()
        {
            UniqueFileIdentifierFrame frame = new UniqueFileIdentifierFrame(ffs, _data);

            Assert.AreEqual(_expOwnerID, frame.OwnerID);
            CollectionAssert.AreEqual(_expValue, frame.GetData());
        }

        [TestMethod]
        public void TestUFID()
        {
            Mp3Tag test = new Mp3Tag(_fileNameUFID);

            Assert.AreEqual(_expOwnerID, test.Id3v2.UFID[0].OwnerID);
            CollectionAssert.AreEqual(_expValue, test.Id3v2.UFID[0].GetData());
        }

        [ExpectedException(typeof(elp87.TagReader.id3v2.Exceptions.InvalidUfidDataException))]
        [TestMethod]
        public void TestInvalidUfidDataException()
        {
            byte[] _invalidData = new byte[] 
            { 
                0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x77, 0x77, 0x77, 0x2E, 0x63, 0x64, 0x64, 0x62, 0x2E, 
                0x63, 0x6F, 0x6D, 0x2F, 0x69, 0x64, 0x33, 0x2F, 0x74, 0x61, 0x67, 0x69, 0x6E, 0x66, 0x6F, 0x31, 
                0x2E, 0x68, 0x74, 0x6D, 0x6C, 0x00, 0x33, 0x43, 0x44, 0x33, 0x4E, 0x39, 0x33, 0x51, 0x32, 0x36, 
                0x39, 0x33, 0x36, 0x35, 0x39, 0x33, 0x32, 0x55, 0x32, 0x31, 0x38, 0x35, 0x43, 0x34, 0x43, 0x41, 
                0x31, 0x34, 0x44, 0x35, 0x43, 0x44, 0x32, 0x32, 0x39, 0x46, 0x38, 0x38, 0x37, 0x37, 0x32, 0x36, 
                0x42, 0x30, 0x31, 0x31, 0x36, 0x44, 0x38, 0x42, 0x38, 0x42, 0x42, 0x50, 0x32, 0x33, 0x33, 0x33,
                0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33
            };

            UniqueFileIdentifierFrame frame = new UniqueFileIdentifierFrame(ffs, _invalidData);
        }
    }
}
