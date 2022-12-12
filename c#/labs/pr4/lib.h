void count_check(int* arr, int len);
void print(int* arr, int len);
void scan(int* arr, int len);

struct array {
  int len, arr[35], count;
};

// #include "lib.h"

// #include <stdio.h>
// #include <stdlib.h>

// void print(int* arr, int len) {
//   for (int i = 0; i < len; i++) {
//     printf("elem %d:%d\n", i + 1, arr[i]);
//   }
// }

// void scan(int* arr, int len) {
//   for (int i = 0; i < len; i++) {
//     printf("Enter elem %d: ", i + 1);
//     if (scanf("%d", arr[i]) != 1) {
//       printf("ERROR INPUT");
//       i--;
//     }
//   }
// }
// void count_check(int* arr, int len) {
//   int count = 0;
//   for (int i = 0; i < len; i++) {
//     if (arr[i] % 3 == 0 && arr[i] % 5 != 0) count++;
//   }
//   printf("Count elements true condition: %d", count);
// }
