#ifndef _ARRAYLIST_H
#define _ARRAYLIST_H

typedef struct array {
    char *data;
    size_t capacity;
    size_t size;
    size_t objectSize;
} array_t;

__declspec(dllexport) array_t *allocateArray(size_t initialCapacity, size_t objectSize);

__declspec(dllexport) void deallocateArray(array_t *array);

__declspec(dllexport) void insert(array_t *array, size_t index, char *item);

__declspec(dllexport) char *getItem(array_t *array, int32_t index);

__declspec(dllexport) int32_t binarySearch(array_t *array, char *item, int32_t (*comparer)(const char *, const char *));

#endif