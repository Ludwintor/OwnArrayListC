#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <math.h>
#include "arraylist.h"

array_t *allocateArray(size_t initialCapacity, size_t objectSize) {
    array_t *array = malloc(sizeof(array_t));
    array->data = malloc(initialCapacity * objectSize);
    array->objectSize = objectSize;
    array->size = 0;
    array->capacity = initialCapacity * objectSize;
    return array;
}

void deallocateArray(array_t *array) {
    free(array->data);
    free(array);
}

void insert(array_t *array, size_t index, char *item) {
    expandIfFull(array);
    size_t insertAt = index * array->objectSize;
    insertAt = insertAt < array->size ? insertAt : array->size;
    int32_t end = array->size - 1;
    int32_t i;
    for (i = end; i >= insertAt; i--)
        array->data[i + array->objectSize] = array->data[i];
    for (i = 0; i < array->objectSize; i++)
        array->data[insertAt + i] = item[i];
    array->size += array->objectSize;
}

char *getItem(array_t *array, int32_t index) {
    return array->data + index * array->objectSize;
}

int32_t binarySearch(array_t *array, char *item, int32_t (*comparer)(const char *, const char *)) {
    int min = 0;
    int max = getSize(array) - 1;
    while (min <= max) {
        int mid = (min + max) / 2;
        int32_t compare = comparer(item, getItem(array, mid));
        if (compare == 0)
            return mid;
        else if (compare > 0)
            min = mid + 1;
        else
            max = mid - 1;
    }
    return -1;
}

size_t getSize(array_t *array) {
    return array->size / array->objectSize;
}

void expandIfFull(array_t *array) {
    if (array->size != array->capacity)
        return;
    array->capacity *= 2;
    array->data = realloc(array->data, array->capacity * array->objectSize);
}