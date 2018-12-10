﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BeatmapConverter {
    private const int version = 12;

    private static List<string> lines;

    public static void ConvertToOsuFile()
    {
        lines = new List<string>();
        Misc("osu file format v" + version);

        #region GENERAL
        Section("General");
        Pair("AudioFilename", "none.mp3"); // TODO IMPORTANT
        Pair("AudioLeadIn", "0"); // TODO IMPORTANT
        Pair("PreviewTime", "0"); // TODO
        Pair("Countdown", "0"); // TODO
        Pair("SampleSet", "Soft"); // TODO
        Pair("StackLeniency", "0"); // TODO
        Pair("Mode", "2");
        Pair("LetterboxInBreaks", "0"); // TODO
        Pair("WidescreenStoryboard", "0"); // TODO
        #endregion

        #region EDITOR
        Section("Editor");
        Pair("Bookmarks", "0"); // TODO
        Pair("DistanceSpacing", "0"); // TODO
        Pair("BeatDivisor", "0"); // TODO IMPORTANT
        Pair("GridSize", "0"); // TODO
        Pair("TimelineZoom", "1"); // TODO
        #endregion

        #region METADATA
        Section("Metadata");
        Pair("Title", "Never gonna give you up"); // TODO IMPORTANT
        Pair("TitleUnicode", "0"); // TODO IMPORTANT
        Pair("Artist", "Rick Astley"); // TODO IMPORTANT
        Pair("ArtistUnicode", "0"); // TODO IMPORTANT
        Pair("Creator", "CTB EDITOR"); // TODO IMPORTANT
        Pair("Version", "Diff name"); // TODO IMPORTANT
        Pair("Source", ""); // TODO
        Pair("Tags", ""); // TODO
        Pair("BeatmapID", "0");
        Pair("BeatmapSetID", "0");
        #endregion

        #region TIMINGPOINTS
        Section("Difficulty");
        Pair("HPDrainRate", "7"); // TODO
        Pair("CircleSize", "5"); // TODO
        Pair("OverallDifficulty", "5"); // TODO
        Pair("ApproachRate", ApproachRateUI.Instance.approachRate.ToString());
        Pair("SliderMultiplier", "1"); // TODO
        Pair("SliderTickRate", "1"); // TODO
        #endregion

        #region EVENTS
        Section("Events"); // TODO
        #endregion

        #region TIMINGPOINTS
        Section("TimingPoints"); // TODO REALLY IMPORTANT, FOR THE MOMENT ONLY 1 POINT AT 0 OFFSET WILL BE PUT
        TimingPoint(0, 60000f / BpmUI.Instance.BPM, 4, 2, 1, 100, 0);
        #endregion

        #region COLOURS
        Section("Colours");
        Misc("Combo1: 255, 0, 0");
        Misc("Combo2: 0, 255, 0");
        Misc("Combo3: 0, 0, 255");
        #endregion

        #region HITOBJECTS
        Section("HitObjects");

        #endregion
    }

    private static void Misc(string str)
    {
        lines.Add(str);
    }

    private static void Section(string str)
    {
        lines.Add("");
        lines.Add(string.Format("[{0}]", str));
    }

    private static void Pair(string parameter, string value)
    {
        lines.Add(string.Format("{0}: {1}", parameter, value));
    }

    private static void TimingPoint(int offset, double mspb, int meter, int sampleSet, int sampleIndex, int volume, byte kiaiMode)
    {
        byte inherited = (mspb < 0) ? (byte)0 : (byte)1;

        lines.Add(string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", offset.ToString(), mspb.ToString(), meter.ToString(), sampleSet.ToString(), sampleIndex.ToString(), volume.ToString(), inherited.ToString(), kiaiMode.ToString()));
    }

}
