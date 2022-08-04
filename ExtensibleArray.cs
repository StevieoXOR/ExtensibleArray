using System.Collections.Generic;

//static void Main()	//Can't be public nor in the class nor at the end of the file
{
	(new ExtensibleArray<bool>()).Test();
}

//The  ClassName<datatype>  indicates the type passed in when an ExtensibleArray Object is created.   I.e. uses Generics.
//where datatype: class  means datatype MUST be a class like string or Array (and NOT a primitive like int or bool)
public class ExtensibleArray<datatype> //where datatype: class
//The <datatype> above means every instantiation of an Object belonging to this class must be like the following:
//	ExtensibleArray<someType> arrayName = new ExtensibleArray<someType>();
{
	readonly static int defaultCapacity = 0;
	public bool[]   ArrayB = new bool[defaultCapacity];	//Can only be instantiated with STATIC ints for some reason
	public char[]   ArrayC = new char[defaultCapacity];
	public short[]  Array_sho = new short[defaultCapacity];
	public int[]    ArrayI = new int[defaultCapacity];
	public long[]   ArrayL = new long[defaultCapacity];
	public float[]  ArrayF = new float[defaultCapacity];
	public double[] ArrayD = new double[defaultCapacity];
	public string[] Array_str = new string[defaultCapacity];

	//ArrayList() is NOT a generic collection. One ArrayList can store several different types like ints and Objects together
	//List<T>() is a generic collection.       Must specify a type parameter for the type of data it can store.
	
	//the Type datatype is from when this class is instantiated (at the very top)
	public List<datatype> ArrayT0 = new List<datatype>();
	public datatype[] ArrayT1 = new datatype[defaultCapacity];

	//private _size because letting size be modified without altering the size of the array (capacity) as well is a recipe for disaster
	//  with letting Print() print items at indices that shouldn't be accessible
	private long Bsize = 0;
	private long Csize = 0;
	private long shoSize = 0;
	private long Isize = 0;
	private long Lsize = 0;
	private long Fsize = 0;
	private long Dsize = 0;
	private long strSize = 0;
	private long datatypeSize = 0;
	
	//capacity  == arrayLength == totalMemoryAllocatedForArrayToStoreStuff
	//Bcapacity == ArrayB.LongLength or ArrayB.Length
	private long Bcapacity = defaultCapacity;
	private long Ccapacity = defaultCapacity;
	private long shoCapacity = defaultCapacity;
	private long Icapacity = defaultCapacity;
	private long Lcapacity = defaultCapacity;
	private long Fcapacity = defaultCapacity;
	private long Dcapacity = defaultCapacity;
	private long strCapacity = defaultCapacity;
	private long datatypeCapacity = defaultCapacity;

	//Append()		                            Adds item to end of type-dependent Array
	//Append<ObjType>()		                    Adds item to end of type-dependent Array
	//Prepend()                                 Adds item to start of type-dependent Array
	//Prepend<ObjType>()                        Adds item to start of type-dependent Array
	//Embiggen(short xAmt, int addedAmt)        Enlarges the type-dependent Array's maxCapacity by xAmt times
	//PrintAll()                  Prints ALL Arrays to screen
	//PrintX()                    Prints type-dependent Array to screen
	//PrintAll_toString()         Stores ALL Array info in a string
	//PrintX_toString()           Stores type-dependent Array info in a string
	public void Append(bool b)	//Adds bool to end of array
	{
		if(Bsize == Bcapacity)	//if(capacityOfBoolArray hasBeenReached)    i.e. if(boolArrayIsFull)
		{
			bool[] largerArray = new bool[Bcapacity*10+1];	//Create empty boolArray that is 10x larger (+1 in case of size0)
			ArrayB.CopyTo(largerArray,0);					//Copies all values of ArrayB into largerArray starting at destIndex 0
			ArrayB = largerArray;							//Sets ArrayB to point to the location of the 10xlarger boolArray
			Bcapacity = Bcapacity*10+1;
		}
		ArrayB[Bsize++] = b;	//Sets the next open location to the passed in bool b
	}
	public void Append(char c)	//Adds char to end of array
	{
		if(Csize == Ccapacity)	//if(capacityOfCharArray hasBeenReached)    i.e. if(CharArrayIsFull)
		{
			char[] largerArray = new char[Ccapacity*10+1];	//Create empty charArray that is 10x larger (+1 in case of size0)
			ArrayC.CopyTo(largerArray,0);					//Copies all values of ArrayC into largerArray starting at destIndex 0
			ArrayC = largerArray;							//Sets ArrayC to point to the location of the 10xlarger charArray
			Ccapacity = Ccapacity*10+1;
		}
		ArrayC[Csize++] = c;	//Sets the next open location to the passed in char c
	}
	public void Append(short sho)	//Adds short to end of array
	{
		if(shoSize == shoCapacity)	//if(capacityOfShortArray hasBeenReached)    i.e. if(ShortArrayIsFull)
		{
			short[] largerArray = new short[shoCapacity*10+1];	//Create empty shortArray that is 10x larger (+1 in case of size0)
			Array_sho.CopyTo(largerArray,0);					//Copies all values of Array_sho into largerArray starting at destIndex 0
			Array_sho = largerArray;							//Sets Array_sho to point to the location of the 10xlarger shortArray
			shoCapacity = shoCapacity*10+1;
		}
		Array_sho[shoSize++] = sho;	//Sets the next open location to the passed in short sho
	}
	public void Append(int i)	//Adds int to end of array
	{
		if(Isize == Icapacity)	//if(capacityOfIntArray hasBeenReached)    i.e. if(intArrayIsFull)
		{
			int[] largerArray = new int[Icapacity*10+1];//Create empty intArray that is 10x larger (+1 in case of size0)
			ArrayI.CopyTo(largerArray,0);				//Copies all values of ArrayI into largerArray starting at destIndex 0
			ArrayI = largerArray;						//Sets ArrayI to point to the location of the 10xlarger intArray
			Icapacity = Icapacity*10+1;
		}
		ArrayI[Isize++] = i;								//Sets the next open location to the passed in int i
	}
	public void Append(long l)
	{
		if(Lsize == Lcapacity)
		{
			long[] largerArray = new long[Lcapacity*10+1];
			ArrayL.CopyTo(largerArray,0);
			ArrayL = largerArray;
			Lcapacity = Lcapacity*10+1;
		}
		ArrayL[Lsize++] = l;
	}
	public void Append(float f)
	{
		if(Fsize == Fcapacity)
		{
			float[] largerArray = new float[Fcapacity*10+1];
			ArrayF.CopyTo(largerArray,0);
			ArrayF = largerArray;
			Fcapacity = Fcapacity*10+1;
		}
		ArrayF[Fsize++] = f;
	}
	public void Append(double d)
	{
		if(Dsize == Dcapacity)
		{
			double[] largerArray = new double[Dcapacity*10+1];
			ArrayD.CopyTo(largerArray,0);
			ArrayD = largerArray;
			Dcapacity = Dcapacity*10+1;
		}
		ArrayD[Dsize++] = d;
	}
	public void Append(string s)
	{
		if(strSize == strCapacity)
		{
			string[] largerArray = new string[strCapacity*10+1];
			Array_str.CopyTo(largerArray,0);
			Array_str = largerArray;
			strCapacity = strCapacity*10+1;
		}
		Array_str[strSize++] = s;
	}
	/*public void Append<DATATYPE>(datatype dt) where DATATYPE:class
	{
		if(datatypeSize == datatypeCapacity)
		{
			datatype[] largerArray = new datatype[datatypeCapacity*10+1];
			ArrayT1.CopyTo(largerArray,0);
			ArrayT1 = largerArray;
			datatypeCapacity = datatypeCapacity*10+1;
		}
		ArrayT1[datatypeSize++] = dt;
	}*/
	public void Append(datatype dt)
	{
		//I think this method takes precedent over the other Append()s??? Idk and idk how the compiler knows which to pick
		if(datatypeSize == datatypeCapacity)
		{
			datatype[] largerArray = new datatype[datatypeCapacity*10+1];
			ArrayT1.CopyTo(largerArray,0);
			ArrayT1 = largerArray;
			datatypeCapacity = datatypeCapacity*10+1;
		}
		ArrayT1[datatypeSize++] = dt;
	}



	//Somewhat resource intensive, though nowhere remotely near as bad as using a for() loop moving one element rightward at a time
	//This method copies entire blocks of data at a time.
	public void Prepend(bool b)
	{
		if(Bsize == Bcapacity)
		{
			bool[] largerArray = new bool[Bcapacity*10+1];
			Bcapacity = Bcapacity*10+1;
			ArrayB.CopyTo(largerArray,1);
			ArrayB = largerArray;
		}
		else
		{
			bool[] largerArray = new bool[++Bcapacity];
			ArrayB.CopyTo(largerArray,1);
			ArrayB = largerArray;
		}
		ArrayB[0] = b;
		Bsize++;
	}
	public void Prepend(char c)
	{
		if(Csize == Ccapacity)
		{
			char[] largerArray = new char[Ccapacity*10+1];
			Ccapacity = Ccapacity*10+1;
			ArrayC.CopyTo(largerArray,1);
			ArrayC = largerArray;
		}
		else
		{
			char[] largerArray = new char[++Ccapacity];
			ArrayC.CopyTo(largerArray,1);
			ArrayC = largerArray;
		}
		ArrayC[0] = c;
		Csize++;
	}
	public void Prepend(short sho)
	{
		if(shoSize == shoCapacity)
		{
			short[] largerArray = new short[shoCapacity*10+1];
			shoCapacity = shoCapacity*10+1;
			Array_sho.CopyTo(largerArray,1);
			Array_sho = largerArray;
		}
		else
		{
			short[] largerArray = new short[++shoCapacity];
			Array_sho.CopyTo(largerArray,1);
			Array_sho = largerArray;
		}
		Array_sho[0] = sho;
		shoSize++;
	}
	public void Prepend(int i)
	{
		if(Isize == Icapacity)
		{
			int[] largerArray = new int[Icapacity*10+1];
			Icapacity = Icapacity*10+1;
			ArrayI.CopyTo(largerArray,1);
			ArrayI = largerArray;
		}
		else
		{
			int[] largerArray = new int[++Icapacity];
			ArrayI.CopyTo(largerArray,1);
			ArrayI = largerArray;
		}
		ArrayI[0] = i;
		Isize++;
	}
	public void Prepend(long l)
	{
		if(Lsize == Lcapacity)
		{
			long[] largerArray = new long[Lcapacity*10+1];
			Lcapacity = Lcapacity*10+1;
			ArrayL.CopyTo(largerArray,1);
			ArrayL = largerArray;
		}
		else
		{
			long[] largerArray = new long[++Lcapacity];
			ArrayL.CopyTo(largerArray,1);
			ArrayL = largerArray;
		}
		ArrayL[0] = l;
		Lsize++;
	}
	public void Prepend(float f)
	{
		if(Fsize == Fcapacity)
		{
			float[] largerArray = new float[Fcapacity*10+1];
			Fcapacity = Fcapacity*10+1;
			ArrayF.CopyTo(largerArray,1);
			ArrayF = largerArray;
		}
		else
		{
			float[] largerArray = new float[++Fcapacity];
			ArrayF.CopyTo(largerArray,1);
			ArrayF = largerArray;
		}
		ArrayF[0] = f;
		Fsize++;
	}
	public void Prepend(double d)
	{
		long ArrayDFormerLength = ArrayD.LongLength;
		if(Dsize == ArrayDFormerLength)
		{
			double[] largerArray = new double[ArrayDFormerLength*10+1];
			Dcapacity = Dcapacity*10+1;
			ArrayD.CopyTo(largerArray,1);
			ArrayD = largerArray;
		}
		else
		{
			double[] largerArray = new double[++Dcapacity];
			ArrayD.CopyTo(largerArray,1);
			ArrayD = largerArray;
		}
		ArrayD[0] = d;
		Dsize++;
	}
	public void Prepend(string s)
	{
		if(strSize == strCapacity)		//if(Array_str is full)
		{
			//Prepend za:     Array_str[ab]        largerArray["",          "","","","",  "","","","",""] 1)
			//                                     largerArray[overwriteMe!,"","","","",  "","","","",""] 2)
			//           Arystr.CopyTo(lrgrAry) => largerArray[overwriteMe!,ab,"","","",  "","","","",""] 3)
			//                    lrgrAry[0]=za => largerArray[za,          ab,"","","",  "","","","",""] 5)
			//                                       Array_str[za,          ab,"","","",  "","","","",""] 4)
			string[] largerArray = new string[strCapacity*10+1];	//1) Create empty stringArray that is 10x larger (+1 in case of size0)
			strCapacity = strCapacity*10+1;
			//UNNECESSARY    largerArray[0] = "overwriteMe!";		//2) Set the first array item to something to make it not empty
			Array_str.CopyTo(largerArray,1);	//3) Copy entire srcArray to the destination array starting at destArray index1
			Array_str = largerArray;			//4) Reassign the array
		}
		else
		{
			//Prepend za:        Array_str[ab,bc]  largerArray["","",  ""]         1)
			//                                     largerArray[overwriteMe!,"",""] 2)
			//           Arystr.CopyTo(lrgrAry) => largerArray[overwriteMe!,ab,""] 3)
			//                                       Array_str[za,          ab,""] 4)
			//                    lrgrAry[0]=za => largerArray[za,          ab,""] 5)
			string[] largerArray = new string[++strCapacity];		//1) Create empty stringArray that is 1 element larger
			//UNNECESSARY    largerArray[0] = "overwriteMe!";		//2) Set the first array item to something to make it not empty
			Array_str.CopyTo(largerArray,1);	//3) Copy entire srcArray to the destination array starting at destArray index1
			Array_str = largerArray;			//4) Reassign the array
		}
		Array_str[0] = s;					//5) Overwrite the placeholding element
		strSize++;
	}
	public void Prepend<DATATYPE>(datatype someObject) where DATATYPE: class
	{
		//PROBLEM: WHAT IF THE USER DECLARES DATATYPE TO BE DIFFERENT THAN THE CLASS'S datatype???
		//PROBLEM: string IS A CLASS AND MIGHT USE THIS METHOD INSTEAD OF  Prepend(string s). THIS CLASS WILL
		// NOT MODIFY THE string ARRAY, ONLY ArrayT1.
		//datatype IS NOT A Type AND CANNOT BE COMPARED TO Type FOR SOME REASON, MEANING
		//  NO REDIRECTIONS TO METHOD Prepend(string s) IF THIS METHOD IS CALLED WITH A string ARGUMENT
		//SOLUTION: This method cannot be called without specifying the angle brackets like Prepend<string>("lol");,
		//  meaning this method will never be mistaken for another Prepend() method like Prepend("lol");
		if(datatypeSize == datatypeCapacity)		//if(datatypeArray is full)
		{
			//Prepend za:     dtArray[ab]         largerArray["",          "","","","",  "","","","",""] 1)
			//                                    largerArray[overwriteMe!,"","","","",  "","","","",""] 2)
			//           dtAry.CopyTo(lrgrAry) => largerArray[overwriteMe!,ab,"","","",  "","","","",""] 3)
			//                   lrgrAry[0]=za => largerArray[za,          ab,"","","",  "","","","",""] 5)
			//                                        dtArray[za,          ab,"","","",  "","","","",""] 4)
			datatype[] largerArray = new datatype[datatypeCapacity*10+1];	//1) Create empty stringArray that is 10x larger (+1 in case of size0)
			datatypeCapacity = datatypeCapacity*10+1;
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
			datatype[] largerArray = new datatype[++datatypeCapacity];		//1) Create empty stringArray that is 1 element larger
			//UNNECESSARY    largerArray[0] = "overwriteMe!";				//2) Set the first array item to something to make it not empty
			ArrayT1.CopyTo(largerArray,1);	//3) Copy entire srcArray to the destination array starting at destArray index1
			ArrayT1 = largerArray;			//4) Reassign the array
		}
		ArrayT1[0] = someObject;			//5) Overwrite the placeholding element
		datatypeSize++;
	}



	public bool Embiggen(short xAmt, long addedAmt, Type T)
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

		//None require a primitive in their constructor except for string... Weird.
		//Can also use typeof(primitive)
		Type BOOLEAN  = (new bool())    .GetType();
		Type CHAR     = (new char())    .GetType();
		Type SHORT    = (new short())   .GetType();
		Type INT      = typeof(int);
		Type LONG     = (new long())    .GetType();
		Type FLOAT    = (new float())   .GetType();
		Type DOUBLE   = (new double())  .GetType();
		Type STRING   = (new string("")).GetType();
		if(T==BOOLEAN)
		{
			Array longerArray = Array.CreateInstance(typeof(bool),Bcapacity*xAmt+addedAmt);	//Create new empty array with size (currSize*xAmt+addedAmt)
			ArrayB.CopyTo(longerArray,0);						//Copies all data from ArrayB into longerArray starting at longerArray[0]
			ArrayB = (bool[])longerArray;						//Reassigns memory address of ArrayB to memory address of longerArray
			Bcapacity = Bcapacity*xAmt+addedAmt;				//Resets Bcapacity to the new actual array capacity
		}
		else if(T==CHAR)
		{
			char[] longerArray = new char[Ccapacity*xAmt+addedAmt];
			ArrayC.CopyTo(longerArray,0);
			ArrayC = longerArray;
			Ccapacity = Ccapacity*xAmt+addedAmt;
		}
		else if(T==SHORT)
		{
			short[] longerArray = new short[shoCapacity*xAmt+addedAmt];
			Array_sho.CopyTo(longerArray,0);
			Array_sho = longerArray;
			shoCapacity = shoCapacity*xAmt+addedAmt;
		}
		else if(T==INT)
		{
			int[] longerArray = new int[Icapacity*xAmt+addedAmt];
			//ArrayI.CopyTo(longerArray,0);
			Array.Copy(ArrayI,longerArray,Isize);
			ArrayI = longerArray;
			Icapacity = Icapacity*xAmt+addedAmt;
		}
		else if(T==LONG)
		{
			long[] longerArray = new long[Lcapacity*xAmt+addedAmt];
			ArrayL.CopyTo(longerArray,0);
			ArrayL = longerArray;
			Lcapacity = Lcapacity*xAmt+addedAmt;
		}
		else if(T==FLOAT)
		{
			float[] longerArray = new float[Fcapacity*xAmt+addedAmt];
			ArrayF.CopyTo(longerArray,0);
			ArrayF = longerArray;
			Fcapacity = Fcapacity*xAmt+addedAmt;
		}
		else if(T==DOUBLE)
		{
			double[] longerArray = new double[Dcapacity*xAmt+addedAmt];
			ArrayD.CopyTo(longerArray,0);
			ArrayD = longerArray;
			Dcapacity = Dcapacity*xAmt+addedAmt;
		}
		else if(T==STRING)
		{
			string[] longerArray = new string[strCapacity*xAmt+addedAmt];
			Array_str.CopyTo(longerArray,0);
			Array_str = longerArray;
			strCapacity = strCapacity*xAmt+addedAmt;
		}
		else
		{
			Console.WriteLine("ERROR: Unsupported nonprimitive and nonstring type");
			return false;
		}
		//No new elements are added, so size doesn't change
		return true;
	}


	//To print out "}" or "{" (but not to put in a string), it must be doubled up as "}}" or "{{" (like an escape character)
	public void PrintAll()
	{
		PrintB();
		PrintC();
		PrintSho();
		PrintI();
		PrintL();
		PrintF();
		PrintD();
		PrintStr();
	}
	public void PrintB()		//Print out boolArray
	{
		Console.Write("{0}/{1}B: {{", Bsize, Bcapacity);
		for(long i=0; i<Bsize-1; i++)
		{
			if(ArrayB[i]){	Console.Write("1");}	//if(currElementIsTrue){ Print"1";}
			else{			Console.Write("0");}	//if(currElementIsFalse){Print"0";}
				 if((i+1)%8==0 && i>0){Console.Write("  ");}
			else if((i+1)%4==0 && i>0){Console.Write(" ");}
		}
		if(Bsize > 0)				//if(arrayHasAtLeastOneElement)
		{
			if(ArrayB[Bsize-1]){Console.WriteLine("1}");}	//if(currElementIsTrue){ Print"1}\n";}
			else{				Console.WriteLine("0}");}	//if(currElementIsFalse){Print"0}\n";}
		}
		else{				Console.WriteLine("}");}
	}
	public void PrintC()		//Print out charArray
	{
		Console.Write("{0}/{1}C: {{", Csize, Ccapacity);
		for(long i=0; i<Csize-1; i++){	Console.Write( $"{ArrayC[i]}" );}
		if(Csize > 0){	Console.WriteLine( $"{ArrayC[Csize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public void PrintSho()		//Print out shortArray
	{
		Console.Write("{0}/{1}s: {{", shoSize, shoCapacity);
		for(long i=0; i<shoSize-1; i++){Console.Write( $"{Array_sho[i]}, " );}
		if(shoSize-1 > 0){	Console.WriteLine( $"{Array_sho[shoSize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public void PrintI()		//Print out intArray
	{
		Console.Write("{0}/{1}I: {{", Isize, Icapacity);
		for(long i=0; i<Isize-1; i++){	Console.Write( $"{ArrayI[i]}, " );}
		if(Isize > 0){	Console.WriteLine( $"{ArrayI[Isize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public void PrintL()		//Print out longArray
	{
		Console.Write("{0}/{1}L: {{", Lsize, Lcapacity);
		for(long i=0; i<Lsize-1; i++){	Console.Write( $"{ArrayL[i]}, " );}
		if(Lsize > 0){	Console.WriteLine( $"{ArrayL[Lsize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public void PrintF()		//Print out floatArray
	{
		Console.Write("{0}/{1}F: {{", Fsize, Fcapacity);
		for(long i=0; i<Fsize-1; i++){	Console.Write( $"{ArrayF[i]}, " );}
		if(Fsize > 0){	Console.WriteLine( $"{ArrayF[Fsize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public void PrintD()		//Print out doubleArray
	{
		Console.Write("{0}/{1}D: {{", Dsize, Dcapacity);
		for(long i=0; i<Dsize-1; i++){	Console.Write( $"{ArrayD[i]}, " );}
		if(Dsize > 0){	Console.WriteLine( $"{ArrayD[Dsize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public void PrintStr()		//Print out stringArray
	{
		Console.Write("{0}/{1}S: {{", strSize, strCapacity);
		for(long i=0; i<strSize-1; i++){Console.Write( $"{Array_str[i]}, " );}
		if(strSize > 0){	Console.WriteLine( $"{Array_str[strSize-1]}}}" );}
		else{				Console.WriteLine("}");}
	}
	public string PrintAll_ToString()
	{
		string s = PrintB_toString();
		s += PrintC_toString();
		s += PrintSho_toString();
		s += PrintI_toString();
		s += PrintL_toString();
		s += PrintF_toString();
		s += PrintD_toString();
		s += PrintStr_toString();
		return s;
	}
	public string PrintB_toString()
	{
		string s = Bsize+"/"+Bcapacity+"B: {";					//Print out #nonNullElementsInArray/capacityOfArray Boolean:
		for(long i=0; i<Bsize-1; i++)							//Store bool Array into a string
		{
			if(ArrayB[i]){	s += "1";}	//if(currElementIsTrue){ add"1"toString;}
			else{			s += "0";}	//if(currElementIsFalse){add"0"toString;}
				if((i+1)%8==0 && i>0){s += "  ";}
			else if((i+1)%4==0 && i>0){s += " ";}
		}
		if(Bsize > 0){	string a=ArrayB[Bsize-1] ? s+="1" : s+="0";}	//string a is unused but necessary for the ternary operation
		return (s+"}\n");						//The  s += "}\n";  is not combined in the above line because of possibly empty arrays
	}
	public string PrintC_toString()		//Store char Array into a string
	{
		string s = Csize+"/"+Ccapacity+"C: {";
		for(long i=0; i<Csize-1; i++){	s += ArrayC[i]+", ";}
		if(Csize > 0){	s += ArrayC[Csize-1];}
		return (s+"}\n");
	}
	public string PrintSho_toString()	//Store short Array into a string
	{
		string s = shoSize+"/"+shoCapacity+"s: {";
		for(long i=0; i<shoSize-1; i++){s += Array_sho[i]+", ";}
		if(shoSize > 0){	s += Array_sho[shoSize-1];}
		return (s+"}\n");
	}
	public string PrintI_toString()		//Store int Array into a string
	{
		string s = Isize+"/"+Icapacity+"I: {";
		for(long i=0; i<Isize-1; i++){	s += ArrayI[i]+", ";}
		if(Isize > 0){	s += ArrayI[Isize-1];}
		return (s+"}\n");
	}
	public string PrintL_toString()		//Store long Array into a string
	{
		string s = Lsize+"/"+Lcapacity+"L: {";
		for(long i=0; i<Lsize-1; i++){	s += ArrayL[i]+", ";}
		if(Lsize > 0){	s += ArrayL[Lsize-1];}
		return (s+"}\n");
	}
	public string PrintF_toString()		//Store float Array into a string
	{
		string s = Fsize+"/"+Fcapacity+"F: {";
		for(long i=0; i<Fsize-1; i++){	s += ArrayF[i]+", ";}
		if(Fsize > 0){	s += ArrayF[Fsize-1];}
		return (s+"}\n");
	}
	public string PrintD_toString()		//Store double Array into a string
	{
		string s = Dsize+"/"+Dcapacity+"D: {";
		for(long i=0; i<Dsize-1; i++){	s += ArrayD[i]+", ";}
		if(Dsize > 0){	s += ArrayD[Dsize-1];}
		return (s+"}\n");
	}
	public string PrintStr_toString()	//Store string(or String) Array into a string
	{
		string s = strSize+"/"+strCapacity+"S: {";
		for(long i=0; i<strSize-1; i++){s += Array_str[i]+", ";}
		if(strSize > 0){	s += Array_str[strSize-1];}
		return (s+"}\n");
	}
	




	public void Test()
	{
		//Array.CopyTo() experimentation
		string[] ss0 = new string[5];	//{"","","","",""}
		string[] ss1 = {"00","01"};
		ss1.CopyTo(ss0,0);				//{"00","01","","",""}
		Console.WriteLine("{0},{1},{2}\n\n",ss0[0],ss0[1],ss0[2]);


		ExtensibleArray<bool>   ea0 = new ExtensibleArray<bool>();
		ExtensibleArray<string> ea1 = new ExtensibleArray<string>();
		//ExtensibleArray ea1 = new ExtensibleArray();
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
		ea0.Prepend(S0);
		ea0.Prepend(S1);
		ea0.Prepend(S2);
		ea0.Prepend(b0);
		ea0.Prepend(b1);
		ea0.Prepend(c0);
		ea0.Prepend(c1);
		ea0.Prepend(c2);
		ea0.Prepend(s0);
		ea0.Prepend(s1);
		ea0.Prepend(s2);
		ea0.Prepend(i0);
		ea0.Prepend(i1);
		ea0.Prepend(i2);
		ea0.Prepend(f0);
		ea0.Prepend(f1);
		ea0.Prepend(f2);
		ea0.Prepend(l0);
		ea0.Prepend(l1);
		ea0.Prepend(l2);
		ea0.Prepend(d0);
		ea0.Prepend(d1);
		ea0.Prepend(d2);
		ea1.Append(S0);
		ea1.Append(S1);
		ea1.Append(S2);
		ea1.Append(b0);
		ea1.Append(b1);
		ea1.Append(c0);
		ea1.Append(c1);
		ea1.Append(c2);
		ea1.Append(s0);
		ea1.Append(s1);
		ea1.Append(s2);
		ea1.Append(i0);
		ea1.Append(i1);
		ea1.Append(i2);
		ea1.Append(l0);
		ea1.Append(l1);
		ea1.Append(l2);
		ea1.Append(f0);
		ea1.Append(f1);
		ea1.Append(f2);
		ea1.Append(d0);
		ea1.Append(d1);
		ea1.Append(d2);
		
		ea0.ArrayB[10] = true;
		ea0.Bsize+=5;			//THIS SHOULD NOT BE ALLOWED

		Console.WriteLine( ea0.PrintAll_ToString() );
		Console.WriteLine( ea1.PrintAll_ToString() );

		Console.Write("BoolArray: {0}", ea0.PrintB_toString());
		ea0.Embiggen(0,0,typeof(bool));
		Console.Write("BoolArray: {0}", ea0.PrintB_toString());
		ea0.Embiggen(1,0,typeof(bool));
		Console.Write("BoolArray: {0}", ea0.PrintB_toString());
		ea0.Embiggen(1,1,typeof(bool));
		Console.Write("BoolArray: {0}", ea0.PrintB_toString());
		ea0.Embiggen(2,0,typeof(bool));
		Console.Write("BoolArray: {0}", ea0.PrintB_toString());
		ea0.Embiggen(2,1,typeof(bool));
		Console.WriteLine("BoolArray: {0}", ea0.PrintB_toString());

		Console.Write("CharArray: {0}", ea0.PrintC_toString());
		ea0.Embiggen(0,0,typeof(char));
		Console.Write("CharArray: {0}", ea0.PrintC_toString());
		ea0.Embiggen(1,0,typeof(char));
		Console.Write("CharArray: {0}", ea0.PrintC_toString());
		ea0.Embiggen(1,1,typeof(char));
		Console.Write("CharArray: {0}", ea0.PrintC_toString());
		ea0.Embiggen(2,0,typeof(char));
		Console.Write("CharArray: {0}", ea0.PrintC_toString());
		ea0.Embiggen(2,1,typeof(char));
		Console.WriteLine("CharArray: {0}", ea0.PrintC_toString());

		Console.Write("ShortArray: {0}", ea0.PrintSho_toString());
		ea0.Embiggen(0,0,typeof(short));
		Console.Write("ShortArray: {0}", ea0.PrintSho_toString());
		ea0.Embiggen(1,0,typeof(short));
		Console.Write("ShortArray: {0}", ea0.PrintSho_toString());
		ea0.Embiggen(1,1,typeof(short));
		Console.Write("ShortArray: {0}", ea0.PrintSho_toString());
		ea0.Embiggen(2,0,typeof(short));
		Console.Write("ShortArray: {0}", ea0.PrintSho_toString());
		ea0.Embiggen(2,1,typeof(short));
		Console.WriteLine("ShortArray: {0}", ea0.PrintSho_toString());

		Console.Write("IntArray: {0}", ea0.PrintI_toString());
		ea0.Embiggen(0,0,typeof(int));
		Console.Write("IntArray: {0}", ea0.PrintI_toString());
		ea0.Embiggen(1,0,typeof(int));
		Console.Write("IntArray: {0}", ea0.PrintI_toString());
		ea0.Embiggen(1,1,typeof(int));
		Console.Write("IntArray: {0}", ea0.PrintI_toString());
		ea0.Embiggen(2,0,typeof(int));
		Console.Write("IntArray: {0}", ea0.PrintI_toString());
		ea0.Embiggen(2,1,typeof(int));
		Console.WriteLine("IntArray: {0}", ea0.PrintI_toString());

		Console.Write("LongArray: {0}", ea0.PrintL_toString());
		ea0.Embiggen(0,0,typeof(long));
		Console.Write("LongArray: {0}", ea0.PrintL_toString());
		ea0.Embiggen(1,0,typeof(long));
		Console.Write("LongArray: {0}", ea0.PrintL_toString());
		ea0.Embiggen(1,1,typeof(long));
		Console.Write("LongArray: {0}", ea0.PrintL_toString());
		ea0.Embiggen(2,0,typeof(long));
		Console.Write("LongArray: {0}", ea0.PrintL_toString());
		ea0.Embiggen(2,1,typeof(long));
		Console.WriteLine("LongArray: {0}", ea0.PrintL_toString());

		Console.Write("FloatArray: {0}", ea0.PrintF_toString());
		ea0.Embiggen(0,0,typeof(float));
		Console.Write("FloatArray: {0}", ea0.PrintF_toString());
		ea0.Embiggen(1,0,typeof(float));
		Console.Write("FloatArray: {0}", ea0.PrintF_toString());
		ea0.Embiggen(1,1,typeof(float));
		Console.Write("FloatArray: {0}", ea0.PrintF_toString());
		ea0.Embiggen(2,0,typeof(float));
		Console.Write("FloatArray: {0}", ea0.PrintF_toString());
		ea0.Embiggen(2,1,typeof(float));
		Console.WriteLine("FloatArray: {0}", ea0.PrintF_toString());

		Console.Write("DoubleArray: {0}", ea0.PrintD_toString());
		ea0.Embiggen(0,0,typeof(double));
		Console.Write("DoubleArray: {0}", ea0.PrintD_toString());
		ea0.Embiggen(1,0,typeof(double));
		Console.Write("DoubleArray: {0}", ea0.PrintD_toString());
		ea0.Embiggen(1,1,typeof(double));
		Console.Write("DoubleArray: {0}", ea0.PrintD_toString());
		ea0.Embiggen(2,0,typeof(double));
		Console.Write("DoubleArray: {0}", ea0.PrintD_toString());
		ea0.Embiggen(2,1,typeof(double));
		Console.WriteLine("DoubleArray: {0}", ea0.PrintD_toString());

		Console.Write("StringArray: {0}", ea0.PrintStr_toString());
		ea0.Embiggen(0,0,typeof(string));
		Console.Write("StringArray: {0}", ea0.PrintStr_toString());
		ea0.Embiggen(1,0,typeof(string));
		Console.Write("StringArray: {0}", ea0.PrintStr_toString());
		ea0.Embiggen(1,1,typeof(string));
		Console.Write("StringArray: {0}", ea0.PrintStr_toString());
		ea0.Embiggen(2,0,typeof(string));
		Console.Write("StringArray: {0}", ea0.PrintStr_toString());
		ea0.Embiggen(2,1,typeof(string));
		Console.WriteLine("StringArray: {0}", ea0.PrintStr_toString());

		ea0.PrintAll();
		ea1.PrintAll();
	}
}