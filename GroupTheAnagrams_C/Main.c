#include<stdio.h>
#include<string.h>



void main()
{
	int ch; 
	const char* arr[5];
	const char *answer[4][4];		// A two dimensional array for sorting the anagrams
	int i = 0; 
	int same; 

	printf("Welcome to Group the Anagrams!\n\tThis program is written in C.\n"); 
	printf("\t\t--Griffin Fujioka\n\n"); 

	printf("Your anagrams: \n\trat,\n\tatr,\n\tdog\n\ttra\n"); 

	
	arr[0] = "rat"; 
	arr[1] = "atr"; 
	arr[2] = "dog"; 
	arr[3] = "tra"; 
	arr[4] = NULL;

	while(arr[i] != NULL)
	{

		same = CompareWords(arr[i], arr[i+1]); 
	
		i++; 
	}

			
	printf("Press any key to exit..."); 
	ch = getchar(); 
}

int CompareWords(const char* w1, const char* w2)
{
	const char* substring1; 
	const char* substring2; 
	int length1 = strlen(w1); 
	int length2 = strlen(w2); 
	int i=0;
	int charIndex; 

	if(length1 != length2)
		return 0;		// Lengths not equal == no dice 

	if(length1 == 0)
		return 1; 
	 

	while(w1[i+1])
	{
		printf("%c", w1[i]); 
		charIndex = StringContains(w2, w1[i]); 
		if(charIndex >= 0)		// If we found the character in w2 
		{
			// Create a substring of each of the original strings by removing w[i]
			substring1 = CreateSubstring(w1, i); 
			substring2 = CreateSubstring(w2, charIndex); 
		}
		printf("%c", w2[i]); 

		if(w1[i] != w2[i+1])
			return 0; 

		
		i++;
	}

	printf("\n"); 
}

// Returns the index of c if the string str contains the character c, else returns -1 
int StringContains(const char* str, char c)
{
	int i = 0; 

	while(str[i])
	{
		if(str[i] == c)
			return i; 

		i++; 
	}

	return -1; 
}

// Return a substring of the string str by removing the character at index 
const char* CreateSubstring(const char* str, int index)
{
	return "something";
}