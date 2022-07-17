package com.FileReader;

import com.FileReader.Doc;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class FileReader {
    private ArrayList<Doc> documents = new ArrayList<Doc>();

    public ArrayList<Doc> readFiles() {
        String [] filesName = detectFilesName();

        for (int i = 0; i < filesName.length; i++) {
                File file = new File("D:\\Code Star\\FileReader\\tests\\" + filesName[i]);
                String contex = getFileContex(file);

                documents.add(new Doc(filesName[i], contex));
        }

        return documents;
    }
    public String getFileContex (File file) {
        String contex = "";

        try {
            Scanner scanner = new Scanner(file);

            while (scanner.hasNextLine()) {
                contex += scanner.nextLine();
            }
        }

        catch (FileNotFoundException exception) {
            exception.printStackTrace();
        }

        return contex;
    }

    public String [] detectFilesName() {

        File file = new File("D:\\Code Star\\FileReader\\tests");
        String [] filesName = file.list();
        return  filesName;
    }
}
