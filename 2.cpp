#include <windows.h>
#include <iostream>
#include <locale>
#include <string>

using namespace std;

//алфавит
char arr[34] =
{ 'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я', ' '};

//длина блока
const int blocklength = 17;

//количество блоков
int colblock;

//функция шифрования
int func[2][blocklength] =
{ 
	{0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16}, // новое место
	{2,16,9,14,10,3,1,13,0,12,7,8,5,15,11,4,6}  // старое место
};

//вывод функции шифрования
void out_func()
{
	cout << "Функция шифрования" << endl;
	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < blocklength; j++)
			cout << func[i][j] << ' ';
		cout << endl;
	}
}

//входная строка
string in_str;

//шифрование
string encode(string in_str)
{
	string encode_str;
	encode_str.resize(blocklength);
	for (int i = 0; i < blocklength; i++) //цикл по блоку входной строки
	{
		encode_str[i] = in_str[(func[1][i])];
	}
	return encode_str;
}

//дешифрация
string decode(string encoded_str)
{
	string decode_str;
	decode_str.resize(blocklength);
	for (int i = 0; i < blocklength; i++) //цикл по блоку кодированной строки
	{
		decode_str[(func[1][i])] = encoded_str[i];
	}
	return decode_str;
}

//проверка вводимых данных
bool proverka(string in_str)
{
	int len = in_str.size();
	bool prov = false;
	for (int i = 0; i < len; i++)
	{
		prov = false;
		for (int j = 0; j < 34; j++)
		{
			if (in_str[i] == arr[j])
			{
				prov = true; break;
			}
		}
		if (prov == false) break;
	}
	if (prov == false) return false;
	else return true;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "Шифрование данных методом перестановки" << endl;
	out_func();
	cout << "Введите строку для шифрования: (кириллица верхнего регистра)" << endl;
	do
	{
		getline(cin, in_str);
	} while (!proverka(in_str));
	int len = in_str.length();
	colblock = len / blocklength;
	int ostat = len % blocklength;
	if (ostat != 0)
	{
		in_str.resize((colblock + 1)*blocklength);
		for (int i = 0; i < (blocklength - ostat); i++)
		{
			in_str[((colblock * blocklength) + (len % blocklength) + i)] = ' ';
		}
	};
	string encode_str;
	//шифрование блоков
	for (int i = 0; i <= colblock; i++)
	{
		encode_str += encode(in_str.substr(blocklength*i, blocklength));
	}
	string decode_str;
	//дешифрация блоков
	for (int i = 0; i <= colblock; i++)
	{
		decode_str += decode(encode_str.substr(blocklength*i, blocklength));
	}
	cout << "Шифрованная строка: " << encode_str << endl;
	cout << "Расшифрованная строка: " << decode_str << endl;
	system("pause");
}