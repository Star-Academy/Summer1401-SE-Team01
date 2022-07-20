package com;

import java.util.ArrayList;

public class SplitedInput {
    private ArrayList<String> includeAll = new ArrayList<>();
    private ArrayList<String> excludeAll = new ArrayList<>();
    private ArrayList<String> includeOne = new ArrayList<>();

    public ArrayList<String> getIncludeAll () { return includeAll; }
    public ArrayList<String> getIncludeOne () { return includeOne; }
    public ArrayList<String> getExcludeAll () { return excludeAll; }
}