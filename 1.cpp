#include <windows.h>
#include <iostream>
#include <locale>
#include <string>

using namespace std;

//массив таблицы замены
char arr[2][33] =
{
	{'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'},
	{'Ш','Ь','Т','У','Ъ','Ч','Ю','Ы','Ц','Э','Д','З','К','Е','Ж','Ф','Л','Х','Б','П','С','Я','Р','В','О','И','М','Н','Щ','Г','А','Й','Ё' }
};

//входная строка
string in_str;

//вывод таблицы замены
void out_arr()
{
	cout << "Таблица замен:" << endl;
	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 33; j++)
			cout << arr[i][j] << " ";
		cout << endl;
	}
}

//шифрование
string encode(string in_str, int len)
{
	string encode_str = in_str;
	for (int i = 0; i < len; i++)
	{
		for (int j = 0; j < 33; j++)
			if (encode_str[i] == arr[0][j])
			{
				encode_str[i] = arr[1][j];
				break;
			}
	}
	return encode_str;
}

//дешифрация
string decode(string encoded_str, int len)
{
	string decode_str = encoded_str;
	for (int i = 0; i < len; i++)
	{
		for (int j = 0; j < 33; j++)
			if (decode_str[i] == arr[1][j])
			{
				decode_str[i] = arr[0][j];
				break;
			}
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
		for (int j = 0; j < 33; j++)
		{
			if (in_str[i] == arr[0][j])
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

	cout << "Шифрование данных методом подстановки" << endl;
	out_arr();
	do
	{
		cout << "Введите строку для шифрования: (кириллица верхнего регистра)" << endl;
		cin >> in_str;
	} while (!proverka(in_str));
	int len = in_str.size();
	string encode_str = encode(in_str, len);
	cout << "Шифрованная строка: " << encode_str << endl;
	cout << "Расшифрованная строка: " << decode(encode_str, len) << endl;
	system("pause");
}