#include <windows.h>
#include <iostream>
#include <locale>
#include <string>

using namespace std;

//входная строка
string in_str;

//начальные условия
const int A = 25, B = 256, C = 37, T0 = 7;

//шифрование
string encode(string in_str, int len, int* T)
{
	string encode_str = in_str;
	cout << "Шифрованная строка в ASCII: " << endl;
	//наложим полученную гамму на открытый текст
	for (int i = 0; i < len; i++)
	{
		encode_str[i] = (T[i] + encode_str[i]) % B;
		cout << (int)(unsigned char)(encode_str[i]) << " ";
	}
	return encode_str;
}

//дешифрация
string decode(string encoded_str, int len, int* T)
{
	string decode_str = encoded_str;
	//расшифровка
	for (int i = 0; i < len; i++)
	{
		decode_str[i] = ((decode_str[i] - T[i]) < 0) ? decode_str[i] - T[i] + B : decode_str[i] - T[i];
	}
	return decode_str;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "Шифрование данных методом линейного шифрования данных (граммирование)" << endl;
	cout << "Введите строку для шифрования: " << endl;
	// Длинныый пример: АБВГД!ЮЯ@абвгд#юя$ABCDE%YZ^abcde&yz_012- 89+-*/,.?
	getline(cin, in_str);
	cout << "Входная строка в ASCII:" << endl;
	int len = in_str.size();
	for (int i = 0; i < len; i++)
	{
		cout << (int) (unsigned char) in_str[i] << " ";
	}
	cout << endl;
	int *T = new int[len];
	cout << "Генерируем элементы граммы:" << endl;
	T[0] = T0;
	for (int i = 0; i < len; i++)
	{
		T[i + 1] = (A*T[i] + C) % B;
		cout << T[i] << " ";
	}
	cout << endl;
	string encode_str = encode(in_str, len, T);
	cout << endl;
	cout << "Шифрованная строка: " << encode_str << endl;
	cout << "Расшифрованная строка: " << decode(encode_str, len, T) << endl;
	system("pause");
}