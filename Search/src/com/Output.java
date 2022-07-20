package com;

import java.util.HashSet;

public class Output {
    public static void print(HashSet<Doc> hashSet) {
        for (Doc documents : hashSet) {
            System.out.println(documents.getName());
        }
    }
}
