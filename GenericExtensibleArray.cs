using System;
using System.Collections;
using System.Collections.Generic;

//static void Main()	//Can't be public nor in the class nor at the end of the file
/*{
	//I just need access to the Test() function. Ignore the GenericExtensibleArray and it being of Type int.
	(new GenericExtensibleArray<int>()).Test();
}*/

//The  ClassName<datatype>  indicates the type passed in when a GenericExtensibleArray Object is created.   I.e. uses Generics.
//where datatype: class  means datatype MUST be a class like string or Array (and NOT a primitive like int or bool)
public class GenericExtensibleArray<datatype> //where datatype: class
//The <datatype> above means every instantiation of an Object belonging to this class must be like the following:
//	GenericExtensibleArray<someType> arrayName = new GenericExtensibleArray<someType>();
{
	readonly static int defaultCapacity = 0;
	//ArrayList() is NOT a generic collection. One ArrayList can store several different types like ints and Objects together
	//List<T>() is a generic collection.       Must specify a type parameter for the type of data it can store.
	
	//the Type datatype is from when this class is instantiated (at the very top)
	public List<datatype> ArrayT0 = new List<datatype>();
	public datatype[] ArrayT1 = new datatype[defaultCapacity];	//Can only be instantiated with STATIC ints for some reason

	//private _size because letting size be modified without altering the size of the array (capacity) as well is a recipe for disaster
	//  with letting Print() print items at indices that shouldn't be accessible
	private long Size = 0;
	
	//capacity  == arrayLength == totalMemoryAllocatedForArrayToStoreStuff
	//Capacity == ArrayB.LongLength or ArrayB.Length
	private long Capacity = defaultCapacity;

	//Append<ObjType>()		                             Adds item to end of type-dependent Array
	//Prepend<ObjType>()                                 Adds item to start of type-dependent Array
	//Embiggen<ObjType>(short xAmt, int addedAmt)        Enlarges the type-dependent Array's maxCapacity by xAmt times
	//Print<ObjType>()             Prints type-dependent Array to screen
	//Print_toString()             Stores ALL Array info in a string
	
	public void Append(datatype someObjectOrPrimitive)
	{
		if(Size == Capacity)
		{
			datatype[] largerArray = new datatype[Capacity*10+1];
			ArrayT1.CopyTo(largerArray,0);
			ArrayT1 = largerArray;
			Capacity = Capacity*10+1;
		}
		ArrayT1[Size++] = someObjectOrPrimitive;
	}



	//Somewhat resource intensive, though nowhere remotely near as bad as using a for() loop moving one element rightward at a time
	//This method copies entire blocks of data at a time.
	public void Prepend(datatype someObjectOrPrimitive)
	{
		if(Size == Capacity)		//if(datatypeArray is full)
		{
			//Prepend za:     dtArray[ab]         largerArray["",          "","","","",  "","","","",""] 1)
			//                                    largerArray[overwriteMe!,"","","","",  "","","","",""] 2)
			//           dtAry.CopyTo(lrgrAry) => largerArray[overwriteMe!,ab,"","","",  "","","","",""] 3)
			//                   lrgrAry[0]=za => largerArray[za,          ab,"","","",  "","","","",""] 5)
			//                                        dtArray[za,          ab,"","","",  "","","","",""] 4)
			datatype[] largerArray = new datatype[Capacity*10+1];	//1) Create empty stringArray that is 10x larger (+1 in case of size0)
			Capacity = Capacity*10+1;
			//UNNECESSARY    largerArray[0] = "overwriteMe!";				//2) Set the first array item to something to make it not empty
			ArrayT1.CopyTo(largerArray,1);	//3) Copy entire srcArray to the destination array starting at destArray index1
			ArrayT1 = largerArray;			//4) Reassign the array
		}
		else
		{
			//Prepend za:        Array_str[ab,bc]  largerArray["","",  ""]         1)
			//                                     largerArray[overwriteMe!,"",""] 2)
			//           Arystr.CopyTo(lrgrAry) => largerArray[overwriteMe!,ab,""] 3)
			//                                       Array_str[za,          ab,""] 4)
			//                    lrgrAry[0]=za => largerArray[za,          ab,""] 5)
			datatype[] largerArray = new datatype[++Capacity];		//1) Create empty stringArray that is 1 element larger
			//UNNECESSARY    largerArray[0] = "overwriteMe!";				//2) Set the first array item to something to make it not empty
			ArrayT1.CopyTo(largerArray,1);	//3) Copy entire srcArray to the destination array starting at destArray index1
			ArrayT1 = largerArray;			//4) Reassign the array
		}
		ArrayT1[0] = someObjectOrPrimitive;	//5) Overwrite the placeholding element
		Size++;
	}



	public bool Embiggen(short xAmt, long addedAmt)
	{
		//WHAT HAPPENS IF ARRAY WOULD BE SMALLER THAN IT WAS PREVIOUSLY (OR IF IT WOULD BE THE SAME SIZE)?
		if(xAmt<1)	//if(multiplier isLessThan 1)												cap*-1 or cap*.5 or cap*0
		{
			Console.WriteLine("Could not embiggen array due to parameters implying array shrinkage.");
			return false;
		}
		else if(xAmt<=1 && addedAmt<1)	//if(multiplier isOneOrLess  AND  addedAmount isLessThan 1)		cap*1+0
		{
			Console.WriteLine("Could not embiggen array due to parameters implying unchanged array capacity.");
			return false;
		}

		datatype[] longerArray = new datatype[Capacity*xAmt+addedAmt];	//Create new empty array with size (currSize*xAmt+addedAmt)
		ArrayT1.CopyTo(longerArray,0);						//Copies all data from ArrayT1 into longerArray starting at longerArray[0]
		ArrayT1 = longerArray;								//Reassigns memory address of ArrayT1 to memory address of longerArray
		Capacity = Capacity*xAmt+addedAmt;					//Resets Capacity to the new actual array capacity
		//No new elements are added, so size doesn't change
		
		return true;
	}


	//To print out "}" or "{" (but not to put in a string), it must be doubled up as "}}" or "{{" (like an escape character)
	public void Print()		//Print out datatypeArray
	{
		Console.Write("{0}/{1}S: {{", Size, Capacity);
		for(long i=0; i<Size-1; i++){Console.Write( $"{ArrayT1[i]}, " );}
		if(Size > 0){	Console.WriteLine( $"{ArrayT1[Size-1]}}}" );}
		else{					Console.WriteLine("}");}
	}
	public string Print_toString()	//Store datatype Array into a string
	{
		string s = Size+"/"+Capacity+"S: {";
		for(long i=0; i<Size-1; i++){s += ArrayT1[i]+", ";}
		if(Size > 0){	s += ArrayT1[Size-1];}
		return (s+"}\n");
	}
	




	public void Test()
	{
		//Array.CopyTo() experimentation
		string[] ss0 = new string[5];	//{"","","","",""}
		string[] ss1 = {"00","01"};
		ss1.CopyTo(ss0,0);				//{"00","01","","",""}
		Console.WriteLine("{0},{1},{2}\n\n",ss0[0],ss0[1],ss0[2]);


		GenericExtensibleArray<bool>   eaB   = new GenericExtensibleArray<bool>();
		GenericExtensibleArray<char>   eaC   = new GenericExtensibleArray<char>();
		GenericExtensibleArray<short>  eaSho = new GenericExtensibleArray<short>();
		GenericExtensibleArray<int>    eaI   = new GenericExtensibleArray<int>();
		GenericExtensibleArray<long>   eaL   = new GenericExtensibleArray<long>();
		GenericExtensibleArray<float>  eaF   = new GenericExtensibleArray<float>();
		GenericExtensibleArray<double> eaD   = new GenericExtensibleArray<double>();
		GenericExtensibleArray<string> eaStr = new GenericExtensibleArray<string>();
		//GenericExtensibleArray<typeof(List<>)> eaX = new GenericExtensibleArray<typeof(List<>)>();	//nonprimitive class
		string S0 = "abcd";
		string S1 = "bcde";
		string S2 = "cdef";
		bool b0 = false;
		bool b1 = true;
		char c0 = char.MaxValue;
		char c1 = char.MinValue;
		char c2 = (char)0;
		short s0 = short.MaxValue;
		short s1 = short.MinValue;
		short s2 = 0;
		int i0 = int.MaxValue;
		int i1 = int.MinValue;
		int i2 = 0;
		long l0 = long.MaxValue;
		long l1 = long.MinValue;
		long l2 = 0;
		float f0 = float.MaxValue;
		float f1 = float.MinValue;
		float f2 = 0;
		double d0 = double.MaxValue;
		double d1 = double.MinValue;
		double d2 = 0;
		eaStr.Prepend(S0);
		eaStr.Prepend(S1);
		eaStr.Prepend(S2);
		eaB.Prepend(b0);
		eaB.Prepend(b1);
		eaC.Prepend(c0);
		eaC.Prepend(c1);
		eaC.Prepend(c2);
		eaSho.Prepend(s0);
		eaSho.Prepend(s1);
		eaSho.Prepend(s2);
		eaI.Prepend(i0);
		eaI.Prepend(i1);
		eaI.Prepend(i2);
		eaF.Prepend(f0);
		eaF.Prepend(f1);
		eaF.Prepend(f2);
		eaL.Prepend(l0);
		eaL.Prepend(l1);
		eaL.Prepend(l2);
		eaD.Prepend(d0);
		eaD.Prepend(d1);
		eaD.Prepend(d2);

		eaStr.Append(S0);
		eaStr.Append(S1);
		eaStr.Append(S2);
		eaB.Append(b0);
		eaB.Append(b1);
		eaC.Append(c0);
		eaC.Append(c1);
		eaC.Append(c2);
		eaSho.Append(s0);
		eaSho.Append(s1);
		eaSho.Append(s2);
		eaI.Append(i0);
		eaI.Append(i1);
		eaI.Append(i2);
		eaF.Append(f0);
		eaF.Append(f1);
		eaF.Append(f2);
		eaL.Append(l0);
		eaL.Append(l1);
		eaL.Append(l2);
		eaD.Append(d0);
		eaD.Append(d1);
		eaD.Append(d2);
		
		eaB.ArrayT1[10] = true;

		Console.Write("BoolArray: {0}", eaB.Print_toString());
		eaB.Embiggen(0,0);
		Console.Write("BoolArray: {0}", eaB.Print_toString());
		eaB.Embiggen(1,0);
		Console.Write("BoolArray: {0}", eaB.Print_toString());
		eaB.Embiggen(1,1);
		Console.Write("BoolArray: {0}", eaB.Print_toString());
		eaB.Embiggen(2,0);
		Console.Write("BoolArray: {0}", eaB.Print_toString());
		eaB.Embiggen(2,1);
		Console.WriteLine("BoolArray: {0}", eaB.Print_toString());

		Console.Write("CharArray: {0}", eaC.Print_toString());
		eaC.Embiggen(0,0);
		Console.Write("CharArray: {0}", eaC.Print_toString());
		eaC.Embiggen(1,0);
		Console.Write("CharArray: {0}", eaC.Print_toString());
		eaC.Embiggen(1,1);
		Console.Write("CharArray: {0}", eaC.Print_toString());
		eaC.Embiggen(2,0);
		Console.Write("CharArray: {0}", eaC.Print_toString());
		eaC.Embiggen(2,1);
		Console.WriteLine("CharArray: {0}", eaC.Print_toString());

		Console.Write("ShortArray: {0}", eaSho.Print_toString());
		eaSho.Embiggen(0,0);
		Console.Write("ShortArray: {0}", eaSho.Print_toString());
		eaSho.Embiggen(1,0);
		Console.Write("ShortArray: {0}", eaSho.Print_toString());
		eaSho.Embiggen(1,1);
		Console.Write("ShortArray: {0}", eaSho.Print_toString());
		eaSho.Embiggen(2,0);
		Console.Write("ShortArray: {0}", eaSho.Print_toString());
		eaSho.Embiggen(2,1);
		Console.WriteLine("ShortArray: {0}", eaSho.Print_toString());

		Console.Write("IntArray: {0}", eaI.Print_toString());
		eaI.Embiggen(0,0);
		Console.Write("IntArray: {0}", eaI.Print_toString());
		eaI.Embiggen(1,0);
		Console.Write("IntArray: {0}", eaI.Print_toString());
		eaI.Embiggen(1,1);
		Console.Write("IntArray: {0}", eaI.Print_toString());
		eaI.Embiggen(2,0);
		Console.Write("IntArray: {0}", eaI.Print_toString());
		eaI.Embiggen(2,1);
		Console.WriteLine("IntArray: {0}", eaI.Print_toString());

		Console.Write("LongArray: {0}", eaL.Print_toString());
		eaL.Embiggen(0,0);
		Console.Write("LongArray: {0}", eaL.Print_toString());
		eaL.Embiggen(1,0);
		Console.Write("LongArray: {0}", eaL.Print_toString());
		eaL.Embiggen(1,1);
		Console.Write("LongArray: {0}", eaL.Print_toString());
		eaL.Embiggen(2,0);
		Console.Write("LongArray: {0}", eaL.Print_toString());
		eaL.Embiggen(2,1);
		Console.WriteLine("LongArray: {0}", eaL.Print_toString());

		Console.Write("FloatArray: {0}", eaF.Print_toString());
		eaF.Embiggen(0,0);
		Console.Write("FloatArray: {0}", eaF.Print_toString());
		eaF.Embiggen(1,0);
		Console.Write("FloatArray: {0}", eaF.Print_toString());
		eaF.Embiggen(1,1);
		Console.Write("FloatArray: {0}", eaF.Print_toString());
		eaF.Embiggen(2,0);
		Console.Write("FloatArray: {0}", eaF.Print_toString());
		eaF.Embiggen(2,1);
		Console.WriteLine("FloatArray: {0}", eaF.Print_toString());

		Console.Write("DoubleArray: {0}", eaD.Print_toString());
		eaD.Embiggen(0,0);
		Console.Write("DoubleArray: {0}", eaD.Print_toString());
		eaD.Embiggen(1,0);
		Console.Write("DoubleArray: {0}", eaD.Print_toString());
		eaD.Embiggen(1,1);
		Console.Write("DoubleArray: {0}", eaD.Print_toString());
		eaD.Embiggen(2,0);
		Console.Write("DoubleArray: {0}", eaD.Print_toString());
		eaD.Embiggen(2,1);
		Console.WriteLine("DoubleArray: {0}", eaD.Print_toString());

		Console.Write("StringArray: {0}", eaStr.Print_toString());
		eaStr.Embiggen(0,0);
		Console.Write("StringArray: {0}", eaStr.Print_toString());
		eaStr.Embiggen(1,0);
		Console.Write("StringArray: {0}", eaStr.Print_toString());
		eaStr.Embiggen(1,1);
		Console.Write("StringArray: {0}", eaStr.Print_toString());
		eaStr.Embiggen(2,0);
		Console.Write("StringArray: {0}", eaStr.Print_toString());
		eaStr.Embiggen(2,1);
		Console.WriteLine("StringArray: {0}", eaStr.Print_toString());

		/*Console.Write("XArray: {0}", eaX.Print_toString());
		eaX.Embiggen(0,0);
		Console.Write("XArray: {0}", eaX.Print_toString());
		eaX.Embiggen(1,0);
		Console.Write("XArray: {0}", eaX.Print_toString());
		eaX.Embiggen(1,1);
		Console.Write("XArray: {0}", eaX.Print_toString());
		eaX.Embiggen(2,0);
		Console.Write("XArray: {0}", eaX.Print_toString());
		eaX.Embiggen(2,1);
		Console.WriteLine("XArray: {0}", eaX.Print_toString());*/

		eaB.Print();
		eaC.Print();
		eaSho.Print();
		eaI.Print();
		eaL.Print();
		eaF.Print();
		eaD.Print();
		eaStr.Print();
		//eaX.Print();
	}
}